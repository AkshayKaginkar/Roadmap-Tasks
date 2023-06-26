using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Session5.Constats;
using Session5.Context;
using Session5.Models;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Session5.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly IMapper _mapper;
        readonly ApplicationDbContext _applicationDbContext;
        readonly IConfiguration _configuration;
        private AppUser _user;
        private const string _loginProvider = "Session5";
        private string _refreshToken = "RefreshToken";

        public AccountRepository(UserManager<AppUser> userManager, IMapper mapper, IConfiguration configuration, ApplicationDbContext applicationDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
            _applicationDbContext = applicationDbContext;
        }
        public bool DeleteUser(AppUser user)
        {
            _applicationDbContext.Users.Remove(user);
            _applicationDbContext.SaveChanges();
            return true;
        }

        public async Task<AppUser> GetUserById(string userId)
        {
            return await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }


        public void  LogOut()
        {
             _signInManager.SignOutAsync();
        }


        public async Task<List<AppUser>> UserList()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<IEnumerable<IdentityError>> Register(RegisterUserDTO registerUser)
        {
            var user = _mapper.Map<AppUser>(registerUser);
            user.UserName = registerUser.Email;
            var result = await _userManager.CreateAsync(user, registerUser.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.User);
            }
            return result.Errors;
        }

        public async Task<AuthResponseDTO> Login(LogInDTO logindto)
        {
            _user = await _userManager.FindByEmailAsync(logindto.Email);
            bool isValidUser = await _userManager.CheckPasswordAsync(_user, logindto.Password);
            if (_user == null || isValidUser == false)
            {
                return null;
            }
            var token = await GenerateToken();
            return new AuthResponseDTO
            {
                Token = token,
                UserId = _user.Id,
                RefreshToken = await CreateRefreshToken()
            };
        }

        private async Task<string> CreateRefreshToken()
        {
            await _userManager.RemoveAuthenticationTokenAsync(_user, _loginProvider, _refreshToken);
            var newrefreshtoken = await _userManager.GenerateUserTokenAsync(_user, _loginProvider, _refreshToken);
            var result = await _userManager.SetAuthenticationTokenAsync(_user, _loginProvider, _refreshToken, newrefreshtoken);
            return newrefreshtoken;
        }

        private async Task<string> GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSetting:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var roles = await _userManager.GetRolesAsync(_user);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
            var userClaims = await _userManager.GetClaimsAsync(_user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,_user.Email ),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, _user.Email),
                new Claim("uid",_user.Id),
            }
            .Union(userClaims).Union(roleClaims);
            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSetting:Issuer"],
                audience: _configuration["JwtSetting:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt64(_configuration["JwtSetting:DurationInMinutes"])),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
            public async Task<AuthResponseDTO> VerifyRefreshToken(AuthResponseDTO request)
            {
                var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                var tokenContenet = jwtSecurityTokenHandler.ReadJwtToken(request.Token);
                var username = tokenContenet.Claims.ToList().FirstOrDefault(t => t.Type == JwtRegisteredClaimNames.Email)?.Value;
                _user = await _userManager.FindByNameAsync(username);
                if (_user == null || _user.Id != request.UserId)
                {
                    return null;
                }
                var isValidRefreshToken = await _userManager.VerifyUserTokenAsync(_user, _loginProvider, _refreshToken, request.RefreshToken);
                if (isValidRefreshToken)
                {
                    var token = await GenerateToken();

                    return new AuthResponseDTO
                    {
                        Token = token,
                        UserId = _user.Id,
                        RefreshToken = await CreateRefreshToken()
                    };

                }

                return null;
            }

        
    }

    
    
}

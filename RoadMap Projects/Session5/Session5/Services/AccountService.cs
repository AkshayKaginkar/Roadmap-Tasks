using Microsoft.AspNetCore.Identity;
using Session5.Context;
using Session5.Models;
using Session5.Repositories;

namespace Session5.Services
{
    public class AccountService : IAccountService
    {
        readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<bool> DeleteUser(string userId)
        {
            var user = await _accountRepository.GetUserById(userId);
            if (user == null)
            {
                return false;
            }
            else
            {
                return _accountRepository.DeleteUser(user);
            }
        }

        public async Task<AuthResponseDTO> Login(LogInDTO logindto)
        {
            return await _accountRepository.Login(logindto);
        }

        public void LogOut()
        {
            _accountRepository.LogOut();
        }

        public async Task<IEnumerable<IdentityError>> Register(RegisterUserDTO user)
        {
            return await _accountRepository.Register(user);
        }

        public async Task<List<AppUser>> UserList()
        {
            return await _accountRepository.UserList();
        }
    }
}

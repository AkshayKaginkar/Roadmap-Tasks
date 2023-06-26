using Microsoft.AspNetCore.Identity;
using Session5.Context;
using Session5.Models;

namespace Session5.Repositories
{
    public interface IAccountRepository
    {
        bool DeleteUser(AppUser user);
        Task<AppUser> GetUserById(string userId);
        Task<AuthResponseDTO> Login(LogInDTO logindto);
        void LogOut();
        Task<IEnumerable<IdentityError>> Register(RegisterUserDTO user);
        Task<List<AppUser>> UserList();
    }
}

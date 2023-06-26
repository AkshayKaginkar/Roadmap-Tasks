using Microsoft.AspNetCore.Identity;
using Session5.Context;
using Session5.Models;

namespace Session5.Services
{
    public interface IAccountService
    {
        Task<bool> DeleteUser(string userId);
        Task<AuthResponseDTO> Login(LogInDTO logindto);
        void LogOut();
        Task<IEnumerable<IdentityError>> Register(RegisterUserDTO user);
        Task<List<AppUser>> UserList();
    }
}

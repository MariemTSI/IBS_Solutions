using System.Collections.Generic;
using System.Threading.Tasks;
using Tsi.Template.Core.Entities;
using Tsi.Template.Core.Models;

namespace Tsi.Template.Core
{
    public interface IUserService
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> GetUserByPhoneNumberAsync(string phoneNumber);
        Task<User> GetUserByIdAsync(int id);
       
        Task CreateUserAsync(User user);
        Task<IEnumerable<UserRole>> GetRolesAsync(User user);
        Task AssignUserToRoleAsync(User user, string userRoleSystemName);
        Task AssignUserToRolesAsync(User user, IEnumerable<string> userRolesSystemNames);
        Task<bool> IsUserAdminAsync(User user);

        Task<bool> ChangeUserPasswordAsync(User user, string oldPassword, string newPassword);

        Task CreatePasswordAsync(User user, string password);
        Task<UserPassword> GetLastPasswordAsync(User user);
        Task<PasswordValidationResult> ValidatePassword(User user, string password);
        Task<User> GetUserByUserNameOrEmail(string username, string email);
        Task UpdateAsync(User user);
    }
}

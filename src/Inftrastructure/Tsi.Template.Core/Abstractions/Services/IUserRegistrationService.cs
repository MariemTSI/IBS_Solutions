using System.Threading.Tasks;
using Tsi.Template.Core.Entities;
using Tsi.Template.Core.Enums;
using Tsi.Template.Core.Models;

namespace Tsi.Template.Core
{
    public interface IUserRegistrationService
    {
        Task<RegisterResult> RegisterUser(UserRegisterModel model);  
        Task<LoginResult> ValidateUser(LoginModel model);
        Task SignInAsync(User user, bool isPersistent);
        Task SignOutAsync();
        Task<User> GetAuthenticatedUserAsync();
    }
}

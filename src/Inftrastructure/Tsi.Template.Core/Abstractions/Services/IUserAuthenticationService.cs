using System.Threading.Tasks;
using Tsi.Template.Core.Entities;

namespace Tsi.Template.Core
{
    public interface IUserAuthenticationService
    {
        Task SignInAsync(User user, bool isPersistent); 
        Task SignOutAsync(); 
        Task<User> GetAuthenticatedUserAsync();
    }
}

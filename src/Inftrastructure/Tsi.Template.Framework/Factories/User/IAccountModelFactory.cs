
using System.Threading.Tasks;
using Tsi.Template.Core.Models;

namespace Tsi.Template.Framework.Factories.User
{
    public interface IAccountModelFactory
    {
        Task<LoginModel> PrepareLoginModelAsync();
        Task<UserRegisterModel> PrepareRegisterModelAsync();
    }
}

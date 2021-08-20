using System.Threading.Tasks;
using Tsi.Template.Core.Entities;

namespace Tsi.Template.Core
{
    public interface IPermissionService
    {
        Task<bool> AuthorizeAsync(Permission permission);
        Task RemovePermissionForRoleAsync(string permissionSystemName, string roleName);
        Task AddPermissionToRoleAsync(string permissionSystemName, string roleName);
    }
}

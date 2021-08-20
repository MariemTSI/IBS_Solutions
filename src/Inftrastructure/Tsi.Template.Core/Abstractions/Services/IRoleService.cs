using System.Collections.Generic;
using System.Threading.Tasks;
using Tsi.Template.Core.Entities;

namespace Tsi.Template.Core
{
    public interface IRoleService
    {
        Task CreateRoleAsync(string systemName, string Name);
        Task CreateRoleAsync(string systemName);
        Task UpdateRoleAsync(int id, string systemName, string name);
        Task<IEnumerable<UserRole>> GetAllRoles();
    }
}

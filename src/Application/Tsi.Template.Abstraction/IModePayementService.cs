using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsi.Template.Domain;
using Tsi.Template.ViewModels;

namespace Tsi.Template.Abstraction
{
    public interface IModePayementService
    {
        public Task<ModePayement> CreateModePayementAsync(ModePayement product);

        public Task DeleteModePayementAsync(int id);
        Task<IEnumerable<ModePayement>> GetAllAsync();
        Task<ModePayement> GetModePayementbyId(int Id);
        Task UpdateModePayementAsync(ModePayementViewModel model);
    }
}

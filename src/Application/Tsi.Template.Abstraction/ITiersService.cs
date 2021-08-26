using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsi.Template.Domain;
using Tsi.Template.ViewModels;

namespace Tsi.Template.Abstraction
{
   public interface ITiersService
    {
        Task<Tiers> CreateTiersAsync(Tiers tiers);
        Task DeleteTiersAsync(int id);
        Task<IEnumerable<Tiers>> GetAllAsync();
        Task<Tiers> GetTiersbyIdAsync(int id);
        Task<Tiers> GetTiersbyCodeAsync(string code);
        Task UpdateTiersAsync(TiersViewModel model);
    }
}

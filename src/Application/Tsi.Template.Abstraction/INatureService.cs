using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsi.Template.Domain;
using Tsi.Template.ViewModels;

namespace Tsi.Template.Abstraction
{
    public interface INatureService
    {
        Task<Nature> CreatePaysAsync(Nature nature);
        Task DeleteNatureAsync(int id);
        Task<IEnumerable<Nature>> GetAllAsync();
        Task<Nature> GetNaturebyCode(string code);
        Task<Nature> GetNaturebyNom(string nom);
        Task<Nature> GetNaturebyId(int Id);
        Task UpdateNatureAsync(NatureViewModel model);
    }
}

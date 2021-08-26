using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsi.Template.Domain;
using Tsi.Template.ViewModels;

namespace Tsi.Template.Abstraction
{
    public interface IComptesComptablesService
    {
        Task<ComptesComptables> CreateComptesComptablesAsync(ComptesComptables comptesComptables);
        Task DeleteComptesComptablesAsync(int id);
        Task<IEnumerable<ComptesComptables>> GetAllAsync();
        Task<ComptesComptables> GetComptesComptablesbyIdAsync(int id);
        Task<ComptesComptables> GetComptesComptablesbyNumeroAsync(string numero);
        Task<ComptesComptables> GetComptesComptablestbyIntituleAsync(string intitule);
        Task UpdateComptesComptablesAsync(ComptesComptablesViewModel model);
    }
}

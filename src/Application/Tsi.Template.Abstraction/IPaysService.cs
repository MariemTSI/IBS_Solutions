using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsi.Template.Domain;
using Tsi.Template.ViewModels;

namespace Tsi.Template.Abstraction
{
    public interface IPaysService
    {
        Task<Pays> CreatePaysAsync(Pays pays);
        Task DeletePaysAsync(int id);
        Task<IEnumerable<Pays>> GetAllAsync();
        Task<Pays> GetPaysbyCode(string code);
        Task<Pays> GetPaysbyNom(string nom);
        Task<Pays> GetPaysbySymboleMonetaire(string symboleMonetaire);
        Task<Pays> GetPaysbyId(int Id);
        Task UpdatePaysAsync(PaysViewModel model);
        
    }
}

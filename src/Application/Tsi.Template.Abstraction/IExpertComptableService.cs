using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsi.Template.Domain;
using Tsi.Template.ViewModels;

namespace Tsi.Template.Abstraction
{
    public interface IExpertComptableService
    {
        Task<ExpertComptable> CreateExpertComptableAsync(ExpertComptable expertComptable);
        Task DeleteExpertComptableAsync(int id);
        Task<IEnumerable<ExpertComptable>> GetAllAsync();
        Task<ExpertComptable> GetExpertComptablebyIdAsync(int id);
        Task<ExpertComptable> GetExpertComptabletbyCodeAsync(string code);

        Task<ExpertComptable> GetExpertComptabletbyNomAsync(string nom);
        Task UpdateExpertComptableAsync (ExpertComptableViewModel model);
       
    }
}

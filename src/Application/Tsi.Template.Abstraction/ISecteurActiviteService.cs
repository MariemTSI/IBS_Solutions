using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsi.Template.Domain;
using Tsi.Template.ViewModels;

namespace Tsi.Template.Abstraction
{
    public interface ISecteurActiviteService
    {
        Task<SecteursActivites> CreateSecteursActivitesAsync(SecteursActivites secteurActivites);
        Task DeleteSecteursActivitesAsync(int id);
        Task<IEnumerable<SecteursActivites>> GetAllAsync();
        Task<SecteursActivites> GetSecteursActivitesbyIdAsync(int id);
        Task<SecteursActivites> GetSecteursActivitesbyNomAsync(string nom);
        Task<SecteursActivites> GetSecteurActivitesbyCodeAsync(string code);
        Task UpdateSecteursActivitesAsync(SecteursActivitesViewModel model);
    }
}

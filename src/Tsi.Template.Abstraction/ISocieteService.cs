using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsi.Template.Domain;

namespace Tsi.Template.Abstraction
{
    public interface ISocieteService
    {
        Task<Societe> CreateSocieteAsync(Societe societe);
        Task DeleteSocieteAsync(int id);
        Task<IEnumerable<Societe>> GetAllAsync();
        Task<Societe> GetSocietebyIdAsync(int id);
        Task<Societe> GetSocietetbyIdentifiantFiscalAsync(string identifiantFiscal);
        Task<Societe> GetSocietetbyCodeAsync(string code);
        Task UpdateSocieteAsync(int id, Societe model);
    }
}

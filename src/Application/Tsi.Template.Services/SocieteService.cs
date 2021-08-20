using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsi.Template.Abstraction;
using Tsi.Template.Core.Attributes;
using Tsi.Template.Domain;
using Tsi.Template.Infrastructure.Repository;

namespace Tsi.Template.Services
{
    [Injectable(typeof(ISocieteService))]
    public class SocieteService : ISocieteService
    {
        private readonly IRepository<Societe> _societeRepo;

        public SocieteService(IRepository<Societe> societeRepo)
        {
            _societeRepo = societeRepo;
        }

        public async Task<Societe> CreateSocieteAsync(Societe societe)
        {
            return await _societeRepo.AddAsync(societe);
        }

        public async Task DeleteSocieteAsync(int id)
        {
            await _societeRepo.DeleteAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Societe>> GetAllAsync()
        {
            return await _societeRepo.GetAllAsync();
        }

        public async Task<Societe> GetSocietebyIdAsync(int id)
        {
            return await _societeRepo.GetByIdAsync(id);
        }

        public async Task<Societe> GetSocietetbyCodeAsync(string code)
        {
            return await _societeRepo.GetAsync(t => t.Code == code);
        }

        public async Task<Societe> GetSocietetbyIdentifiantFiscalAsync(string identifiantFiscal)
        {
            return await _societeRepo.GetAsync(t => t.IdentifiantFiscal == identifiantFiscal);
        }

        public Task UpdateSocieteAsync(int id, Societe model)
        {
            throw new NotImplementedException();
        }
    }
}

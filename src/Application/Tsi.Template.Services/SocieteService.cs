using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsi.Template.Abstraction;
using Tsi.Template.Core.Attributes;
using Tsi.Template.Domain;
using Tsi.Template.Infrastructure.Repository;
using Tsi.Template.ViewModels;

namespace Tsi.Template.Services
{
    [Injectable(typeof(ISocieteService))]
    public class SocieteService : ISocieteService
    {
        private readonly IRepository<Societe> _societeRepo;

        private readonly IRepository<ExpertComptable> _expertComptableRepo;


        public SocieteService(IRepository<Societe> societeRepo, IRepository<ExpertComptable> expertComptableRepo)
        {
            _societeRepo = societeRepo;
            _expertComptableRepo = expertComptableRepo;
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
            var result = await _societeRepo.GetAllAsync();
            foreach( var item in result)
            {
                item.ExpertComptable = await _expertComptableRepo.GetByIdAsync(item.ExpertComptableId);
            }
            return result;
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

        public async Task UpdateSocieteAsync(SocieteViewModel model)
        {
            var societe = await GetSocietebyIdAsync(model.Id);

            if(societe is null)
            {
                return;
            }

            societe.Code = model.Code;
            societe.Nom = model.Nom;
            societe.IdentifiantFiscal = model.IdentifiantFiscal;
            societe.Observation = model.Observation;

            societe.ExpertComptableId = model.ExpertComptableId;

            await _societeRepo.UpdateAsync(societe);
        }
    }
}

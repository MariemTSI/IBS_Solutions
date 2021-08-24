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
    [Injectable(typeof(IExpertComptableService))]
    public class ExpertComptableService : IExpertComptableService
    {
        private readonly IRepository<ExpertComptable> _expertComptableRepo;

        public ExpertComptableService(IRepository<ExpertComptable> expertComptableRepo)
        {
            _expertComptableRepo = expertComptableRepo;
        }

        public async Task<ExpertComptable> CreateExpertComptableAsync(ExpertComptable expertComptable)
        {
            return await _expertComptableRepo.AddAsync(expertComptable);
        }

        public async Task DeleteExpertComptableAsync(int id)
        {
            await _expertComptableRepo.DeleteAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<ExpertComptable>> GetAllAsync()
        {
            return await _expertComptableRepo.GetAllAsync();
        }

      
        public async Task<ExpertComptable> GetExpertComptablebyIdAsync(int id)
        {
            return await _expertComptableRepo.GetByIdAsync(id);
        }

        public async Task<ExpertComptable> GetExpertComptabletbyCodeAsync(string code)
        {
            return await _expertComptableRepo.GetAsync(t => t.Code == code);
        }

        public async Task UpdateExpertComptableAsync(int id, ExpertComptable model)
        {
            var expertComptable = await GetExpertComptablebyIdAsync(id);

            if(expertComptable is null)
            {
                return;
            }

            expertComptable.Code = model.Code;
            expertComptable.Nom = model.Nom;
            expertComptable.Observation = model.Observation;
            expertComptable.PaysId = model.PaysId;
            expertComptable.Societes = model.Societes;
            expertComptable.Ville = model.Ville;
            expertComptable.Adresse = model.Adresse;
            expertComptable.ComplementAdresse = model.ComplementAdresse;
            expertComptable.CP = model.CP;

            await _expertComptableRepo.UpdateAsync(expertComptable);
        }
    }
}

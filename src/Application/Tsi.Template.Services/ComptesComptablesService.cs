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
    [Injectable(typeof(IComptesComptablesService))]
    public class ComptesComptablesService : IComptesComptablesService
    {
        private readonly IRepository<ComptesComptables> _comptesComptableRepo;
        private readonly IRepository<Societe> _societeRepo;

        public ComptesComptablesService(IRepository<ComptesComptables> comptesComptableRepo, IRepository<Societe> societeRepo)
        {
            _comptesComptableRepo = comptesComptableRepo;
            _societeRepo = societeRepo;
        }

        public async Task<ComptesComptables> CreateComptesComptablesAsync(ComptesComptables comptesComptables)
        {
            return await _comptesComptableRepo.AddAsync(comptesComptables);
        }

        public async Task DeleteComptesComptablesAsync(int id)
        {
            await _comptesComptableRepo.DeleteAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<ComptesComptables>> GetAllAsync()
        {
            var result = await _comptesComptableRepo.GetAllAsync();
            foreach (var item in result)
            {
                item.Societe = await _societeRepo.GetByIdAsync(item.SocieteId);
            }
            return result;
        }

        public async Task<ComptesComptables> GetComptesComptablesbyIdAsync(int id)
        {
            return await _comptesComptableRepo.GetByIdAsync(id);
        }

        public async Task<ComptesComptables> GetComptesComptablesbyNumeroAsync(string numero)
        {
            return await _comptesComptableRepo.GetAsync(t => t.Numero == numero);
        }

        public async Task<ComptesComptables> GetComptesComptablestbyIntituleAsync(string intitule)
        {
            return await _comptesComptableRepo.GetAsync(t => t.Intitule == intitule);
        }

        public async Task UpdateComptesComptablesAsync(ComptesComptablesViewModel model)
        {
            var compteComptables = await GetComptesComptablesbyIdAsync(model.Id);

            if(compteComptables is null)
            {
                return;
            }

            compteComptables.Numero = model.Numero;
            compteComptables.Intitule  = model.Intitule;
            compteComptables.NatureCompteComptable = model.NatureCompteComptable;
            compteComptables.Observation = model.Observation;

            compteComptables.SocieteId = model.SocieteId;
        }
    }
}

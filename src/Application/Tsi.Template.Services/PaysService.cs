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
    [Injectable(typeof(IPaysService))]
    public class PaysService : IPaysService
    {
        private readonly IRepository<Pays> _paysRepo;

        public PaysService(IRepository<Pays> paysRepo)
        {
            _paysRepo = paysRepo;
        }

        public async Task<Pays> CreatePaysAsync(Pays pays)
        {
            return await _paysRepo.AddAsync(pays);
        }

        public async Task DeletePaysAsync(int id)
        {
            await _paysRepo.DeleteAsync(t => t.Id==id);
        }

        public async Task<IEnumerable<Pays>> GetAllAsync()
        {
            return await _paysRepo.GetAllAsync();
        }

        public async Task<Pays> GetPaysbyCode(string code)
        {
            return await _paysRepo.GetAsync(t => t.Code == code );
        }

        public async Task<Pays> GetPaysbyId(int Id)
        {
            return await _paysRepo.GetByIdAsync(Id);
        }

        public async Task<Pays> GetPaysbyNom(string nom)
        {
            return await _paysRepo.GetAsync(t => t.Nom == nom);
        }

        public async Task<Pays> GetPaysbySymboleMonetaire(string symboleMonetaire)
        {
            return await _paysRepo.GetAsync(t => t.SymboleMonetaire == symboleMonetaire);
        }

        public async Task UpdatePaysAsync(PaysViewModel model)
        {
            var pays = await GetPaysbyId(model.Id);

            if (pays is null)
            {
                return;
            }

            pays.Nom = model.Nom;
            pays.SymboleMonetaire = model.SymboleMonetaire;
            pays.NbreDecimales = model.NbreDecimales;
            pays.Observation = model.Observation;
            await _paysRepo.UpdateAsync(pays);
        }
    }
}

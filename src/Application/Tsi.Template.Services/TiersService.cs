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
    [Injectable(typeof(ITiersService))]
    public class TiersService : ITiersService
    {
        private readonly IRepository<Tiers> _tiersRepo;
        private readonly IRepository<Pays> _paysRepo;
        private readonly IRepository<SecteursActivites> _secteurActiviteRepo;
        private readonly IRepository<Nature> _natureRepo;

        public TiersService(IRepository<Tiers> tiersRepo, IRepository<Pays> paysRepo, IRepository<SecteursActivites> secteurActiviteRepo, IRepository<Nature> natureRepo)
        {
            _tiersRepo = tiersRepo;
            _paysRepo = paysRepo;
            _secteurActiviteRepo = secteurActiviteRepo;
            _natureRepo = natureRepo;
        }

        public async Task<Tiers> CreateTiersAsync(Tiers tiers)
        {
            return await _tiersRepo.AddAsync(tiers);
        }

        public async Task DeleteTiersAsync(int id)
        {
            await _tiersRepo.DeleteAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Tiers>> GetAllAsync()
        {
            var result = await _tiersRepo.GetAllAsync();
            foreach (var item in result)
            {
                item.Pays = await _paysRepo.GetByIdAsync(item.PaysId);
                item.Nature = await _natureRepo.GetByIdAsync(item.NatureParDefaut);
                item.SecteursAcivites = await _secteurActiviteRepo.GetByIdAsync(item.SecteursActivitesId);

            }
            return result;
        }

        public async Task<Tiers> GetTiersbyCodeAsync(string code)
        {
            return await _tiersRepo.GetAsync(t => t.Code == code);
        }

        public async Task<Tiers> GetTiersbyIdAsync(int id)
        {
            return await _tiersRepo.GetByIdAsync(id);
        }

        public async Task UpdateTiersAsync(TiersViewModel model)
        {
            var tier = await GetTiersbyIdAsync(model.Id);

            if (tier is null)
            {
                return;
            }

            tier.Code = model.Code;
            tier.Type = model.Type;
            tier.Intitule = model.Intitule;
            tier.Observation = model.Observation;
            tier.Adresse = model.Adresse;
            tier.ComplementAdresse = model.ComplementAdresse;
            tier.CP = model.CP;
            tier.Ville = model.Ville;
            tier.PaysId = model.PaysId;
            tier.NatureParDefaut = model.NatureParDefaut;
            tier.SecteursActivitesId = model.SecteurActivitesId;

            await _tiersRepo.UpdateAsync(tier);
        }
    }
}

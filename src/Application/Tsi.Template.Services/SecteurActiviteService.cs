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
    [Injectable(typeof(ISecteurActiviteService))]
    public class SecteurActiviteService : ISecteurActiviteService
    {
        private readonly IRepository<SecteursActivites> _secteurActiviteRepo;

        public SecteurActiviteService(IRepository<SecteursActivites> secteurActiviteRepo)
        {
            _secteurActiviteRepo = secteurActiviteRepo;
        }

        public async Task<SecteursActivites> CreateSecteursActivitesAsync(SecteursActivites secteurActivites)
        {
            return await _secteurActiviteRepo.AddAsync(secteurActivites);
        }

        public async Task DeleteSecteursActivitesAsync(int id)
        {
            await _secteurActiviteRepo.DeleteAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<SecteursActivites>> GetAllAsync()
        {
            return await _secteurActiviteRepo.GetAllAsync();
        }

        public async Task<SecteursActivites> GetSecteursActivitesbyIdAsync(int id)
        {
            return await _secteurActiviteRepo.GetByIdAsync(id);
        }

        public async Task<SecteursActivites> GetSecteursActivitesbyNomAsync(string nom)
        {
            return await _secteurActiviteRepo.GetAsync(t => t.Code == nom);
        }

        public async Task<SecteursActivites> GetSecteurActivitesbyCodeAsync(string code)
        {
            return await _secteurActiviteRepo.GetAsync(t => t.Code == code);
        }

        public async Task UpdateSecteursActivitesAsync(SecteursActivitesViewModel model)
        {
            var secteurActivite = await GetSecteursActivitesbyIdAsync(model.Id);

            if(secteurActivite is null)
            {
                return;
            }

            secteurActivite.Code = model.Code;
            secteurActivite.Nom = model.Nom;
            secteurActivite.Observation = model.Observation;

            await _secteurActiviteRepo.UpdateAsync(secteurActivite);

        }
    }
}

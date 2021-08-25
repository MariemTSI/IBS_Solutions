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

    [Injectable(typeof(INatureService))]
    public class NatureService : INatureService
    {
        private readonly IRepository<Nature> _natureRepo;

        public NatureService(IRepository<Nature> natureRepo)
        {
            _natureRepo = natureRepo;
        }
        public async Task<Nature> CreatePaysAsync(Nature nature)
        {
            return await _natureRepo.AddAsync(nature);
        }

        public async Task DeleteNatureAsync(int id)
        {
            await _natureRepo.DeleteAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Nature>> GetAllAsync()
        {
            return await _natureRepo.GetAllAsync();
        }

        public async Task<Nature> GetNaturebyCode(string code)
        {
            return await _natureRepo.GetAsync(t => t.Code == code);
        }

        public async Task<Nature> GetNaturebyId(int Id)
        {
            return await _natureRepo.GetByIdAsync(Id);
        }

        public async Task<Nature> GetNaturebyNom(string nom)
        {
            return await _natureRepo.GetAsync(t => t.Nom == nom);
        }

        public async Task UpdateNatureAsync(NatureViewModel model)
        {
            var nature = await GetNaturebyId(model.Id);

            if (nature is null)
            {
                return;
            }

            nature.Nom = model.Nom;
            nature.CodeSurDeclaration = model.CodeSurDeclaration;
            nature.Observation = model.Observation;
            await _natureRepo.UpdateAsync(nature);
        }
    }
}

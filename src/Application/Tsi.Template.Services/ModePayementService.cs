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
    [Injectable(typeof(IModePayementService))]
    public class ModePayementService : IModePayementService
    {
        private readonly IRepository<ModePayement> _ModePayementRepo;

        public ModePayementService(IRepository<ModePayement> ModePayementRepo)
        {
            _ModePayementRepo =ModePayementRepo;
        }

        public async Task<ModePayement> CreateModePayementAsync(ModePayement modePayement)
        {
            return await _ModePayementRepo.AddAsync(modePayement);
        }

        public async Task DeleteModePayementAsync(int id)
        {
            await _ModePayementRepo.DeleteAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<ModePayement>> GetAllAsync()
        {
            return await _ModePayementRepo.GetAllAsync();
        }

        public async Task<ModePayement> GetModePayementbyId(int id)
        {
            return await _ModePayementRepo.GetAsync(p => p.Id.Equals(id));
        }

        public async Task UpdateModePayementAsync(ModePayementViewModel modeP)
        {
            var modePayement = await GetModePayementbyId(modeP.Id);

            if (modePayement is null)
            {
                return;
            }

            modePayement.Observation = modeP.Observation;
            modePayement.Nom = modeP.Nom;
            modePayement.CodeSurDeclarationTVA = modeP.CodeSurDeclarationTVA;
            await _ModePayementRepo.UpdateAsync(modePayement);
        }
    }
}

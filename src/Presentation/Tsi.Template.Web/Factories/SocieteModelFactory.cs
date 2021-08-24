using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tsi.Template.Abstraction;
using Tsi.Template.Core.Attributes;
using Tsi.Template.ViewModels;

namespace Tsi.Template.Web.Factories
{
    [Injectable(typeof(ISocieteModelFactory))]
    public class SocieteModelFactory : ISocieteModelFactory
    {
        private readonly ISocieteService _societeService;
        private readonly IExpertComptableService _expertComptableService; 

        public SocieteModelFactory(ISocieteService societeService, IExpertComptableService expertComptableService)
        {
            _societeService = societeService;
            _expertComptableService = expertComptableService;
        }

        public async Task<SocieteViewModel> PopulateExpertComptablsSelectListAsync(SocieteViewModel model)
        {
            model.ExpertComptable = new SelectList(
                (await _expertComptableService.GetAllAsync()).ToDictionary(exp => exp.Id, exp => $"{exp.Code} - {exp.Nom}")
                , "Key"
                , "Value"
                );

            return model;
        }

        public async Task<SocieteViewModel> PrepareSocieteCreateModelAsync(int id)
        {
            var societe = await _societeService.GetSocietebyIdAsync(id);

            if(societe is null)
            {
                throw new ArgumentException("Cannot be null!!", nameof(societe));
            }
            var model = new SocieteViewModel()
            {
                ExpertComptableId = societe.ExpertComptableId,
                Code = societe.Code,
                Nom = societe.Nom,
                IdentifiantFiscal = societe.IdentifiantFiscal,
                Observation = societe.Observation,
                Id = societe.Id
            };

            model = await PopulateExpertComptablsSelectListAsync(model);

            return model;
        }
        public async Task<SocieteViewModel> PrepareSocieteViewModelAsync() => await PopulateExpertComptablsSelectListAsync (new SocieteViewModel());
    }
}

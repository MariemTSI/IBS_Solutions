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
    [Injectable(typeof(IExpertComptableModelFactory))]
    public class ExpertComptableModelFactory : IExpertComptableModelFactory
    {
        private readonly IExpertComptableService _expertComptableService;
        private readonly IPaysService _paysService;

        public ExpertComptableModelFactory(IExpertComptableService expertComptableService, IPaysService paysService)
        {
            _expertComptableService = expertComptableService;
            _paysService = paysService;
        }

        public async Task<ExpertComptableViewModel> PopulatePayssSelectListAsync(ExpertComptableViewModel model)
        {
            model.Pays = new SelectList(
                (await _paysService.GetAllAsync()).ToDictionary(exp => exp.Id, exp => $"{exp.Code} - {exp.Nom}")
                , "Key"
                , "Value"
                );

            return model;
        }

        public async Task<ExpertComptableViewModel> PrepareExpertComptableCreateModelAsync(int id)
        {
            var expertComptable = await _expertComptableService.GetExpertComptablebyIdAsync(id);

            if(expertComptable is null)
            {
                throw new ArgumentException("Cannot be null!!", nameof(expertComptable));
            }

            var model = new ExpertComptableViewModel()
            {
                PaysId = expertComptable.PaysId,
                Code = expertComptable.Code,
                Adresse = expertComptable.Adresse,
                ComplementAdresse = expertComptable.ComplementAdresse,
                CP = expertComptable.CP,
                Id = expertComptable.Id,
                Nom = expertComptable.Nom,
                Observation = expertComptable.Observation,
                Ville = expertComptable.Ville

            };

            model = await PopulatePayssSelectListAsync(model);

            return model;
        }

        public async Task<ExpertComptableViewModel> PrepareExpertComptableViewModelAsync() => await PopulatePayssSelectListAsync(new ExpertComptableViewModel());


    }
}

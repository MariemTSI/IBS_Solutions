using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsi.Template.Domain;
using Tsi.Template.ViewModels;

namespace Tsi.Template.Helpers
{
    public static class ExpertComptableExtensions
    {
        public static ExpertComptable ToExpertComptable(this ExpertComptableViewModel model) => new()
        {
            Code = model.Code,
            Nom = model.Nom,
            Adresse = model.Adresse,
            ComplementAdresse = model.ComplementAdresse,
            CP = model.CP,
            Observation = model.Observation,
            PaysId = model.PaysId,
            Ville = model.Ville,

        };

        public static ExpertComptableViewModel ToViewModel(this ExpertComptable expertComptable) => new()
        {
            Id = expertComptable.Id,
            Code = expertComptable.Code,
            Nom = expertComptable.Nom,
            Adresse = expertComptable.Adresse,
            ComplementAdresse = expertComptable.ComplementAdresse,
            CP = expertComptable.CP,
            Observation = expertComptable.Observation,
            PaysId = expertComptable.PaysId,
            Ville = expertComptable.Ville,

        };

        public static IEnumerable<ExpertComptable> ToExpertComptable(this IEnumerable<ExpertComptableViewModel> models)
            => models.Select(ToExpertComptable);

        public static IEnumerable<ExpertComptableViewModel> ToViewModels(this IEnumerable<ExpertComptable> expertComptables)
            => expertComptables.Select(ToViewModel);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static ListExpertComptableViewModel ToViewModelList(this ExpertComptable expertComptable) => new()
        {
            Id = expertComptable.Id,
            Code = expertComptable.Code,
            Nom = expertComptable.Nom,
            Adresse = expertComptable.Adresse,
            Pays = expertComptable.Pays.Nom,
        };

        public static IEnumerable<ListExpertComptableViewModel> ToViewModelsLists(this IEnumerable<ExpertComptable> expertComptable)
       => expertComptable.Select(ToViewModelList);
    }
}

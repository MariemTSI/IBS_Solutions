using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsi.Template.Domain;
using Tsi.Template.ViewModels;

namespace Tsi.Template.Helpers
{
    public static class SocieteExtensions
    {
        public static Societe ToSociete(this SocieteViewModel model) => new()
        {
            Code = model.Code,
            Nom = model.Nom,
            IdentifiantFiscal = model.IdentifiantFiscal,
            Observation = model.Observation,
            ExpertComptableId = model.ExpertComptableId,

        };

        public static SocieteViewModel ToViewModel(this Societe societe) => new()
        {
            Id = societe.Id,
            Code = societe.Code,
            Nom = societe.Nom,
            IdentifiantFiscal = societe.IdentifiantFiscal,
            Observation = societe.Observation,
            ExpertComptableId = societe.ExpertComptableId,
        };

      

        public static IEnumerable<Societe> ToSocietes(this IEnumerable<SocieteViewModel> models)
            => models.Select(ToSociete);

        public static IEnumerable<SocieteViewModel> ToViewModels(this IEnumerable<Societe> societes)
            => societes.Select(ToViewModel);


        /// ///////////////////////////////////////////////////////////////////////////////////////////

        public static ListSocieteViewModel ToViewModelList(this Societe societe) => new()
        {
            Id = societe.Id,
            Code = societe.Code,
            Nom = societe.Nom,
            NomExpertComptable = societe.ExpertComptable.Nom,
           
        };
        public static IEnumerable<ListSocieteViewModel> ToViewModelsLists(this IEnumerable<Societe> societes)
        => societes.Select(ToViewModelList);
    /*    {
            List<ListSocieteViewModel> result = new List<ListSocieteViewModel>();
            foreach (var item in ToViewModelList)
            {
                var conv = item.ToViewModelList();
                result.Add(conv);
            }
            return result;
        }*/
    }
}

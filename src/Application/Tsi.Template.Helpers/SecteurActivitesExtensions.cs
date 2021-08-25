using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsi.Template.Domain;
using Tsi.Template.ViewModels;

namespace Tsi.Template.Helpers
{
    public static class SecteurActivitesExtensions
    {
        public static SecteursActivites ToSecteurActivite(this SecteursActivitesViewModel model) => new()
        {
            Code = model.Code,
            Nom = model.Nom,
            Observation = model.Observation,
            
        };

        public static SecteursActivitesViewModel ToViewModel(this SecteursActivites secteurActivites) => new()
        {
            Id = secteurActivites.Id,
            Code = secteurActivites.Code,
            Nom = secteurActivites.Nom,
            Observation = secteurActivites.Observation,
        };

        public static IEnumerable<SecteursActivites> ToSecteurActivite(this IEnumerable<SecteursActivitesViewModel> models)
           => models.Select(ToSecteurActivite);

        public static IEnumerable<SecteursActivitesViewModel> ToViewModel(this IEnumerable<SecteursActivites> secteurActivites)
            => secteurActivites.Select(ToViewModel);




        public static ListSecteurActivitesViewModel ToViewModelList(this SecteursActivites secteursActivites) => new()
        {
            Id = secteursActivites.Id,
            Code = secteursActivites.Code,
            Nom = secteursActivites.Nom,
           
        };
        public static IEnumerable<ListSecteurActivitesViewModel> ToViewModelsLists(this IEnumerable<SecteursActivites> secteursActivites)
        => secteursActivites.Select(ToViewModelList);

    }
}

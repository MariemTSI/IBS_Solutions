using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsi.Template.Domain;
using Tsi.Template.ViewModels;

namespace Tsi.Template.Helpers
{
    public static class PaysExtensions
    {
        public static Pays ToPays(this PaysViewModel model) => new()
        {
            Code = model.Code,
            Nom = model.Nom,
            SymboleMonetaire = model.SymboleMonetaire,
            NbreDecimales = model.NbreDecimales,
            Observation = model.Observation,
          
        };
        public static PaysViewModel ToViewModel(this Pays pays) => new()
        {
            Id = pays.Id,
            Code = pays.Code,
            Nom = pays.Nom,
            SymboleMonetaire = pays.SymboleMonetaire,
            NbreDecimales = pays.NbreDecimales,
            Observation = pays.Observation,
        
        };
        public static IEnumerable<Pays> ToPays(this IEnumerable<PaysViewModel> models)
          => models.Select(ToPays);

        public static IEnumerable<PaysViewModel> ToViewModels(this IEnumerable<Pays> pays)
            => pays.Select(ToViewModel);





        public static ListPaysViewModel ToViewModelList(this Pays pays) => new()
        {
            Id = pays.Id,
            Code = pays.Code,
            Nom = pays.Nom,
           

        };
        public static IEnumerable<ListPaysViewModel> ToViewModelsLists(this IEnumerable<Pays> pays)
        => pays.Select(ToViewModelList);
    }
}

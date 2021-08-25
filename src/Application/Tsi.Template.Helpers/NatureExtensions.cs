using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsi.Template.Domain;
using Tsi.Template.ViewModels;

namespace Tsi.Template.Helpers
{
    public static class NatureExtensions
    {
        public static Nature ToNature(this NatureViewModel model) => new()
        {
            Code = model.Code,
            Nom = model.Nom,
            CodeSurDeclaration = model.CodeSurDeclaration,
            Observation = model.Observation,

        };
        public static NatureViewModel ToViewModel(this Nature nature) => new()
        {
            Id = nature.Id,
            Code = nature.Code,
            Nom = nature.Nom,
            CodeSurDeclaration = nature.CodeSurDeclaration,
            Observation = nature.Observation,

        };

        public static IEnumerable<Nature> ToNature(this IEnumerable<NatureViewModel> models)
          => models.Select(ToNature);

        public static IEnumerable<NatureViewModel> ToViewModels(this IEnumerable<Nature> nature)
            => nature.Select(ToViewModel);
    }
}

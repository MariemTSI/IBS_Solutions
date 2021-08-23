using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsi.Template.Domain;
using Tsi.Template.ViewModels;

namespace Tsi.Template.Helpers
{
    public static class ModePayementExtensions
    {
        public static ModePayement ToModePayement(this ModePayementViewModel model) => new()
        {
            Code = model.Code,
            CodeSurDeclarationTVA = model.CodeSurDeclarationTVA,
            Observation = model.Observation,
            Nom = model.Nom
        };

        public static ModePayementViewModel ToViewModel(this ModePayement modeP) => new()
        {
            Code = modeP.Code,
            CodeSurDeclarationTVA = modeP.CodeSurDeclarationTVA,
            Observation = modeP.Observation,
            Nom = modeP.Nom
        };

        public static IEnumerable<ModePayement> ToModePayements(this IEnumerable<ModePayementViewModel> models)
            => models.Select(ToModePayement);

        public static IEnumerable<ModePayementViewModel> ToViewModels(this IEnumerable<ModePayement> modePayements)
            => modePayements.Select(ToViewModel);
    }
}

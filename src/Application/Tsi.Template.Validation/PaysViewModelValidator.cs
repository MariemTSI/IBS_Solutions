using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsi.Template.Abstraction;
using Tsi.Template.ViewModels;
using System.Text.RegularExpressions;

namespace Tsi.Template.Validation
{
    public class PaysViewModelValidator : TsiBaseValidator<PaysViewModel>
    {

        private readonly IPaysService _paysService;
        public PaysViewModelValidator(IPaysService paysService)
        {

            _paysService = paysService;

            RuleFor(p => p.Code)
                .NotEmpty()
                .Must(IsCodeUnique)
                .WithMessage("Code must be unique");

            RuleFor(p => p.Nom).NotNull()
                .NotEmpty()
                .Must(IsNomUnique)
                .WithMessage("Nom must be unique"); ;

            RuleFor(p => p.SymboleMonetaire)
                .NotEmpty()
                .MaximumLength(3)
                .Must(IsSymboleMonetaireUnique)
                .WithMessage("SymboleMonetaire must be unique"); 

            RuleFor(p => p.NbreDecimales)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.Observation)
                .MaximumLength(50);


        }

        public bool IsCodeUnique(PaysViewModel editpays, string newValue)
        {
            var paysWithCode = _paysService.GetPaysbyCode(editpays.Code).GetAwaiter().GetResult();

            return paysWithCode is null ?
                editpays.Code == newValue :
                paysWithCode.Id == editpays.Id || editpays.Code != newValue;
        }

        public bool IsNomUnique(PaysViewModel editpays, string newValue)
        {
            var paysWithNom = _paysService.GetPaysbyNom(editpays.Nom).GetAwaiter().GetResult();

            return paysWithNom is null ?
                editpays.Nom == newValue :
                paysWithNom.Id == editpays.Id || editpays.Nom != newValue;
        }

        public bool IsSymboleMonetaireUnique(PaysViewModel editpays, string newValue)
        {
            var paysWithSymboleMonetaire = _paysService.GetPaysbySymboleMonetaire(editpays.SymboleMonetaire).GetAwaiter().GetResult();

            return paysWithSymboleMonetaire is null ?
                editpays.SymboleMonetaire == newValue :
                paysWithSymboleMonetaire.Id == editpays.Id || editpays.SymboleMonetaire != newValue;
        }
    }
}
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsi.Template.Abstraction;
using Tsi.Template.ViewModels;

namespace Tsi.Template.Validation
{
    public class NatureViewModelValidator : TsiBaseValidator<NatureViewModel>
    {
        private readonly INatureService _natureService;
        public NatureViewModelValidator(INatureService natureService)
        {

            _natureService = natureService;

            RuleFor(n => n.Code)
                .NotEmpty()
                .MaximumLength(3)
                .Must(IsCodeUnique)
                .WithMessage("Code must be unique");

            RuleFor(n => n.Nom).NotNull()
                .NotEmpty()
                .MaximumLength(30)
                .Must(IsNomUnique)
                .WithMessage("Nom must be unique"); ;



            RuleFor(n => n.CodeSurDeclaration)
                .NotNull()
                .MaximumLength(30)
                .NotEmpty();

            RuleFor(n => n.Observation)
                .MaximumLength(50);


        }

        public bool IsCodeUnique(NatureViewModel editnature, string newValue)
        {
            var natureWithCode = _natureService.GetNaturebyCode(editnature.Code).GetAwaiter().GetResult();

            return natureWithCode is null ?
                editnature.Code == newValue :
                natureWithCode.Id == editnature.Id || editnature.Code != newValue;
        }

        public bool IsNomUnique(NatureViewModel editnature, string newValue)
        {
            var natureWithNom = _natureService.GetNaturebyNom(editnature.Nom).GetAwaiter().GetResult();

            return natureWithNom is null ?
                editnature.Nom == newValue :
                natureWithNom.Id == editnature.Id || editnature.Nom != newValue;
        }


    }
}
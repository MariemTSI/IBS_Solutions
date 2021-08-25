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
    public class ExpertComptableViewModelValidator : TsiBaseValidator<ExpertComptableViewModel>
    {
        private readonly IExpertComptableService _expertComptableService;
        private readonly IPaysService _paysService;

        public ExpertComptableViewModelValidator(IExpertComptableService expertComptableService, IPaysService paysService)
        {
            _expertComptableService = expertComptableService;
            _paysService = paysService;


            RuleFor(p => p.Code)
              .NotNull().NotEmpty()
              .WithMessage("Code canoot be empty");

            RuleFor(p => p.Nom)
              .NotNull().NotEmpty()
              .WithMessage("Nom canoot be empty");

            RuleFor(p => p.Adresse)
              .NotNull().NotEmpty()
              .WithMessage("Adresse canoot be empty");

            RuleFor(p => p.CP)
              .NotNull().NotEmpty()
              .WithMessage("CP canoot be empty");

            RuleFor(p => p.Ville)
              .NotNull().NotEmpty()
              .WithMessage("Ville canoot be empty");

            RuleFor(p => p.Code)
               .MaximumLength(3)
               .WithMessage("Code must be 3 digits");

            RuleFor(p => p.Nom)
               .MaximumLength(30)
               .WithMessage("Name must be 30 digits");

            RuleFor(p => p.Adresse)
               .MaximumLength(50)
               .WithMessage("Adress must be 50 digits");

            RuleFor(p => p.CP)
               .MaximumLength(30)
               .WithMessage("CP must be 10 digits");

            RuleFor(p => p.Ville)
               .MaximumLength(30)
               .WithMessage("Ville must be 30 digits");

            RuleFor(p => p.Observation)
              .MaximumLength(50)
              .WithMessage("Observation must be 50 digits");

            RuleFor(p => p.ComplementAdresse)
             .MaximumLength(50)
             .WithMessage("ComplementAdresse must be 50 digits");

            RuleFor(p => p.Code)
               .Must(IsCodeUnique)
               .WithMessage("Code must be unique");


            RuleFor(p => p.Nom)
               .Must(IsNomUnique)
               .WithMessage("Nom must be unique");


        }



        public bool IsCodeUnique(ExpertComptableViewModel ExpertComptableEdited, string newValue)
            {
                var ExpertComptableWithCode = _expertComptableService.GetExpertComptabletbyCodeAsync(ExpertComptableEdited.Code).GetAwaiter().GetResult();

                return ExpertComptableWithCode is null ?
                    ExpertComptableEdited.Code == newValue :
                    ExpertComptableWithCode.Id == ExpertComptableEdited.Id || ExpertComptableEdited.Code != newValue;
            }

        public bool IsNomUnique(ExpertComptableViewModel ExpertComptableEdited, string newValue)
        {
            var ExpertComptableWithNom = _expertComptableService.GetExpertComptabletbyNomAsync(ExpertComptableEdited.Nom).GetAwaiter().GetResult();

            return ExpertComptableWithNom is null ?
                ExpertComptableEdited.Nom == newValue :
                ExpertComptableWithNom.Id == ExpertComptableEdited.Id || ExpertComptableEdited.Nom != newValue;
        }



    }
}

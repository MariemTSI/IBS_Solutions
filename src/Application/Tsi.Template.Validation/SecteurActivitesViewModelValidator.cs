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
    public class SecteurActivitesViewModelValidator : TsiBaseValidator<SecteursActivitesViewModel>
    {
        private readonly ISecteurActiviteService _secteurActiviteService;

        public SecteurActivitesViewModelValidator(ISecteurActiviteService secteurActiviteService)
        {
            _secteurActiviteService = secteurActiviteService;

            RuleFor(p => p.Code)
               .NotNull().NotEmpty()
               .WithMessage("Code canoot be empty");

            RuleFor(p => p.Nom)
               .NotNull().NotEmpty()
               .WithMessage("Name canoot be empty");

            RuleFor(p => p.Nom)
               .MaximumLength(30)
               .WithMessage("Name must be 30 digits");

            RuleFor(p => p.Code)
               .MaximumLength(3)
               .WithMessage("code must be 30 digits");

            RuleFor(p => p.Observation)
              .MaximumLength(50)
              .WithMessage("Observation must be 50 digits");





        }

    }
}

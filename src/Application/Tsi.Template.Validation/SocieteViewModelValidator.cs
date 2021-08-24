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
    public class SocieteViewModelValidator : TsiBaseValidator<SocieteViewModel>
    {
        private readonly ISocieteService _societeService;
        private readonly IExpertComptableService _expertComptableService;

        public SocieteViewModelValidator(ISocieteService SocieteService, IExpertComptableService ExpertComptableService)
        {
            _societeService = SocieteService;
            _expertComptableService = ExpertComptableService;

            RuleFor(p => p.Code)
               .NotNull().NotEmpty()
               .WithMessage("Code canoot be empty");

            RuleFor(p => p.Code)
                .MaximumLength(3)
                .WithMessage("Code must be 3 digits");


            RuleFor(p => p.Nom)
              .NotNull().NotEmpty()
              .WithMessage("Code canoot be empty");

            RuleFor(p => p.Nom)
                .MaximumLength(30)
                .WithMessage("Name must be 30 digits");

            RuleFor(p => p.IdentifiantFiscal)
                .MaximumLength(30)
                .WithMessage("IdentifiantFiscal must be 30 digits");

            RuleFor(p => p.Observation)
                .MaximumLength(50)
                .WithMessage("Observation must be 50 digits");


            RuleFor(p => p.IdentifiantFiscal)
              .NotNull().NotEmpty()
              .WithMessage("Code canoot be empty");

            RuleFor(p => p.Code)
               .Must(IsCodeUnique)
               .WithMessage("Code must be unique");

            RuleFor(p => p.IdentifiantFiscal)
               .Must(IsIdentifianFiscalUnique)
               .WithMessage("Identifiant Fiscal must be unique");

            //RuleFor(p => p.ExpertComptableId).Must(SocieteId =>
            //{
            //    var societe = ex.GetSocietebyIdAsync(SocieteId).GetAwaiter().GetResult();

            //    return societe is not null;
            //}).WithMessage("Societe does not exist in the database");

            //RuleFor(p => p.ExpertComptableId)
            //    .NotEmpty()
            //    .WithMessage("Please enter Expert Comptable");
        }


        public bool IsCodeUnique(SocieteViewModel SocieteEdited, string newValue)
        {
            var societewithCode = _societeService.GetSocietetbyCodeAsync(SocieteEdited.Code).GetAwaiter().GetResult();

            return societewithCode is null ?
                SocieteEdited.Code == newValue :
                societewithCode.Id == SocieteEdited.Id || SocieteEdited.Code != newValue;
        }
        public bool IsIdentifianFiscalUnique(SocieteViewModel SocieteEdited, string newValue)
        {
            var societewithIdentifantFisc = _societeService.GetSocietetbyIdentifiantFiscalAsync(SocieteEdited.IdentifiantFiscal).GetAwaiter().GetResult();

            return societewithIdentifantFisc is null ?
                SocieteEdited.IdentifiantFiscal == newValue :
                societewithIdentifantFisc.Id == SocieteEdited.Id || SocieteEdited.IdentifiantFiscal != newValue;
        }
    }
}



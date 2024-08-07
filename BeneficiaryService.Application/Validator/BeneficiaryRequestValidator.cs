using BeneficiaryService.Application.Dtos.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeneficiaryService.Application.Validator
{
    public class BeneficiaryRequestValidator : AbstractValidator<BeneficiaryRequestDto>
    {
        public BeneficiaryRequestValidator()
        {
            RuleFor(x => x.BeneficiaryName)
               .NotEmpty().WithMessage("Beneficiary name is required.")
               .Length(2, 50).WithMessage("Beneficiary name must be between 2 and 50 characters.");

            RuleFor(x => x.BeneficiaryAccountNumber)
                .NotEmpty().WithMessage("Beneficiary account number is required.")
               .Matches(@"^\d{10}$")
                .WithMessage("Benefactor account number must be 11 digits.");


            RuleFor(x => x.BenefactorName)
                .NotEmpty().WithMessage("Benefactor name is required.")
                .Length(2, 50).WithMessage("Benefactor name must be between 2 and 50 characters.");

            RuleFor(x => x.BenefactorAccountNumber)
                .NotEmpty().WithMessage("Benefactor account number is required.")
                .Matches(@"^\d{10}$")
                .WithMessage("Benefactor account number must be 11 digits.");

            RuleFor(x => x.BenefactorNickname)
                .Length(0, 50).WithMessage("Benefactor nickname must be less than 50 characters.");

            RuleFor(x => x.BankName)
                .NotEmpty().WithMessage("Bank name is required.")
                .Length(2, 50).WithMessage("Bank name must be between 2 and 50 characters.");

            RuleFor(x => x.BankCode)
                .NotEmpty().WithMessage("Bank code is required.")
                .Length(3, 10).WithMessage("Bank code must be between 3 and 10 characters.");

            RuleFor(x => x.Narration)
                .Length(0, 200).WithMessage("Narration must be less than 200 characters.");

        }
    }
}

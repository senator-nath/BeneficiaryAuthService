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
        //public BeneficiaryRequestDtoValidator()
        //{
        //    RuleFor(x => x.BeneficiaryName)
        //        .NotEmpty().WithMessage("Beneficiary Name is required")
        //        .Length(2, 50).WithMessage("Beneficiary Name must be between 2 and 50 characters");

        //    RuleFor(x => x.BeneficiaryAccountNumber)
        //        .NotEmpty().WithMessage("Beneficiary Account Number is required")
        //        .Matches("^[0-9]{10}$").WithMessage("Beneficiary Account Number must be 10 digits");

        //    RuleFor(x => x.BenefactorName)
        //        .NotEmpty().WithMessage("Benefactor Name is required")
        //        .Length(2, 50).WithMessage("Benefactor Name must be between 2 and 50 characters");

        //    RuleFor(x => x.BenefactorAccountNumber)
        //        .NotEmpty().WithMessage("Benefactor Account Number is required")
        //        .Matches("^[0-9]{10}$").WithMessage("Benefactor Account Number must be 10 digits");

        //    RuleFor(x => x.BenefactorNickname)
        //        .NotEmpty().WithMessage("Benefactor Nickname is required")
        //        .Length(2, 50).WithMessage("Benefactor Nickname must be between 2 and 50 characters");

        //    RuleFor(x => x.BankName)
        //        .NotEmpty().WithMessage("Bank Name is required")
        //        .Length(2, 50).WithMessage("Bank Name must be between 2 and 50 characters");

        //    RuleFor(x => x.BankCode)
        //        .NotEmpty().WithMessage("Bank Code is required")
        //        .Matches("^[0-9]{3,5}$").WithMessage("Bank Code must be between 3 and 5 digits");

        //    RuleFor(x => x.Narration)
        //        .Length(200).WithMessage("Narration must be at most 200 characters");
        //}
    }
}

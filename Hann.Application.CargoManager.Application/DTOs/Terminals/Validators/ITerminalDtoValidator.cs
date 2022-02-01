using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.DTOs.Terminals.Validators
{
    public class ITerminalDtoValidator : AbstractValidator<ITerminalDto>
    {
        public ITerminalDtoValidator()
        {
            RuleFor(p => p.TerminalName)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull().WithMessage("{PropertyName} can not be null")
            .MinimumLength(3).WithMessage("{PropertyName} must be greater than {ComparisonValue}")
            .MaximumLength(100).WithMessage("{PropertyName} must not be greater than {ComparisonValue}");

            RuleFor(p => p.TerminalAddress)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull().WithMessage("{PropertyName} can not be null")
            .MinimumLength(5).WithMessage("{PropertyName} must be greater than {ComparisonValue}")
            .MaximumLength(200).WithMessage("{PropertyName} must not be greater than {ComparisonValue}");
            
            RuleFor(p => p.TerminalContactNo)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull().WithMessage("{PropertyName} can not be null")
            .MinimumLength(5).WithMessage("{PropertyName} must be greater than {ComparisonValue}")
            .MaximumLength(20).WithMessage("{PropertyName} must not be greater than {ComparisonValue}");


            RuleFor(s => s.EmailAddress)
                .NotEmpty().WithMessage("Email address is required")
                     .EmailAddress().WithMessage("A valid email is required");

        }
    }
}

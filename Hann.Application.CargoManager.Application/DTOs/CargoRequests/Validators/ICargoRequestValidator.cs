using FluentValidation;
using Hann.Application.CargoManager.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.DTOs.CargoRequests.Validators
{
    public class ICargoRequestValidator : AbstractValidator<ICargoRequestDto>
    {
        private readonly ITerminalRepository _terminalRepository;
        public ICargoRequestValidator(ITerminalRepository terminalRepository)
        {
            _terminalRepository = terminalRepository;

            RuleFor(p => p.CustomerName)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull().WithMessage("{PropertyName} can not be null")
            .MaximumLength(100).WithMessage("{PropertyName} must not be greater than {ComparisonValue}");

            RuleFor(p => p.PhoneNumber)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull().WithMessage("{PropertyName} can not be null")
            .MinimumLength(5).WithMessage("{PropertyName} must be greater than {ComparisonValue}")
            .MaximumLength(200).WithMessage("{PropertyName} must not be greater than {ComparisonValue}");

            RuleFor(s => s.EmailAddress)
                .NotEmpty().WithMessage("Email address is required")
                     .EmailAddress().WithMessage("A valid email is required");

            RuleFor(p => p.DropOffTerminalId)
             .NotEmpty().WithMessage("{PropertyName} is required")
             .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}")
             .MustAsync(async (id, token) =>
             {
                 var terminalExists = await _terminalRepository.Exists(id);
                 return terminalExists;
             }).WithMessage("{PropertyName} does not exist.");

            RuleFor(x => x.DropOffDate)
            .Must(BeAValidDate).WithMessage("dropoffdate is required");

            RuleFor(p => p.DeliveryTerminalId)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}")
            .MustAsync(async (id, token) =>
            {
                var terminalExists = await _terminalRepository.Exists(id);
                return terminalExists;
            }).WithMessage("{PropertyName} does not exist.");

            RuleFor(x => x.DeliveryDate)
               .Must(BeAValidDate).WithMessage("dropoffdate is required");

            RuleFor(p => p.EstimatedWeight)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull().WithMessage("{PropertyName} can not be null")
               .MaximumLength(100).WithMessage("{PropertyName} must not be greater than {ComparisonValue}");

            RuleFor(p => p.ItemSummary)
               .MaximumLength(200).WithMessage("{PropertyName} must not be greater than {ComparisonValue}");

            RuleFor(p => p.ItemDescription)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull().WithMessage("{PropertyName} can not be null")
               .MaximumLength(100).WithMessage("{PropertyName} must not be greater than {ComparisonValue}");
        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}

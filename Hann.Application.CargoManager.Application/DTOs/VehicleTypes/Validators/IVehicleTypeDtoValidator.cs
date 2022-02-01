using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.DTOs.VehicleTypes.Validators
{
    public class IVehicleTypeDtoValidator : AbstractValidator<IVehicleTypeDto>
    {
        public IVehicleTypeDtoValidator()
        {
            RuleFor(p => p.VehicleTypeName)
             .NotEmpty().WithMessage("{PropertyName} is required")
             .NotNull().WithMessage("{PropertyName} can not be null")
             .MinimumLength(3).WithMessage("{PropertyName} must be greater than {ComparisonValue}")
             .MaximumLength(100).WithMessage("{PropertyName} must not be greater than {ComparisonValue}");
        }
    }
}

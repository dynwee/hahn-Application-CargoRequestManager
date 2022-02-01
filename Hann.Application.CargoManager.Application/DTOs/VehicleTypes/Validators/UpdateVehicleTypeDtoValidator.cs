using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.DTOs.VehicleTypes.Validators
{
    public class UpdateVehicleTypeDtoValidator : AbstractValidator<UpdateVehicleTypeDto>
    {
        public UpdateVehicleTypeDtoValidator()
        {
            Include(new IVehicleTypeDtoValidator());
            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

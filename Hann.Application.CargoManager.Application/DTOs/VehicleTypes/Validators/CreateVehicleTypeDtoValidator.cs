using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.DTOs.VehicleTypes.Validators
{
    public class CreateVehicleTypeDtoValidator : AbstractValidator<CreateVehicleTypeDto>
    {
        public CreateVehicleTypeDtoValidator()
        {
            Include(new IVehicleTypeDtoValidator());
        }
    }
}

using FluentValidation;
using Hann.Application.CargoManager.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.DTOs.VehicleAllocations.Validators
{
    public class CreateVehicleAllocationDtoValidator : AbstractValidator<CreateVehicleAllocationDto>
    {
        private readonly IVehicleTypeRepository _vehicleTypeRepository;
        private readonly ICargoRequestRepository _cargoRequestRepository;
        public CreateVehicleAllocationDtoValidator(IVehicleTypeRepository vehicleTypeRepository
            , ICargoRequestRepository cargoRequestRepository)
        {

            _vehicleTypeRepository = vehicleTypeRepository;
            _cargoRequestRepository = cargoRequestRepository;

            Include(new IVehicleAllocationDtoValidator(_vehicleTypeRepository, _cargoRequestRepository));
        }
    }
}

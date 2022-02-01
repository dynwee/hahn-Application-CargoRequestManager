using FluentValidation;
using Hann.Application.CargoManager.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.DTOs.VehicleAllocations.Validators
{
    public class IVehicleAllocationDtoValidator : AbstractValidator<IVehicleAllocationDto>
    {
        private readonly IVehicleTypeRepository _vehicleTypeRepository;
        private readonly ICargoRequestRepository _cargoRequestRepository;
        public IVehicleAllocationDtoValidator(IVehicleTypeRepository vehicleTypeRepository, ICargoRequestRepository cargoRequestRepository)
        {
            _vehicleTypeRepository = vehicleTypeRepository;
            _cargoRequestRepository = cargoRequestRepository;

            RuleFor(p => p.CargoRequestId)
              .NotEmpty().WithMessage("{PropertyName} is required")
              .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}")
              .MustAsync(async (id, token) =>
              {
                  var cargoRequestExists = await _cargoRequestRepository.Exists(id);
                  return !cargoRequestExists;
              }).WithMessage("{PropertyName} does not exist.");

            RuleFor(p => p.VehicleTypeId)
              .NotEmpty().WithMessage("{PropertyName} is required")
              .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}")
              .MustAsync(async (id, token) =>
              {
                  var VehicleTypeExists = await _vehicleTypeRepository.Exists(id);
                  return !VehicleTypeExists;
              }).WithMessage("{PropertyName} does not exist.");

        }
    }
}

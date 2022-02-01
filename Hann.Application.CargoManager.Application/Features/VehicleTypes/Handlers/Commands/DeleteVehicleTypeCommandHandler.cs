using AutoMapper;
using Hann.Application.CargoManager.Application.Exceptions;
using Hann.Application.CargoManager.Application.Features.VehicleTypes.Requests.Commands;
using Hann.Application.CargoManager.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.Features.VehicleTypes.Handlers.Commands
{
    public class DeleteVehicleTypeCommandHandler : IRequestHandler<DeleteVehicleTypeCommand,Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteVehicleTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteVehicleTypeCommand request, CancellationToken cancellationToken)
        {
            var vehicleType = await _unitOfWork.VehicleTypeRepository.GetAsync(request.Id);

            if (vehicleType == null)
                throw new NotFoundException(nameof(vehicleType), request.Id);

            await _unitOfWork.VehicleTypeRepository.DeleteAsync(vehicleType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}

using Hann.Application.CargoManager.Application.Exceptions;
using Hann.Application.CargoManager.Application.Features.VehicleAllocations.Requests.Commands;
using Hann.Application.CargoManager.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.Features.VehicleAllocations.Handlers.Commands
{
    public class DeleteVehicleAllocationCommandHandler : IRequestHandler<DeleteVehicleAllocationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteVehicleAllocationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteVehicleAllocationCommand request, CancellationToken cancellationToken)
        {
            var vehicleAllocation = await _unitOfWork.VehicleAllocationRespository.GetAsync(request.Id);

            if (vehicleAllocation == null)
                throw new NotFoundException(nameof(vehicleAllocation), request.Id);

            await _unitOfWork.VehicleAllocationRespository.DeleteAsync(vehicleAllocation);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}

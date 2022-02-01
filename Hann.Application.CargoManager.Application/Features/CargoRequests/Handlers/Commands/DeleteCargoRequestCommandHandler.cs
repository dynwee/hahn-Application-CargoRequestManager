using Hann.Application.CargoManager.Application.Exceptions;
using Hann.Application.CargoManager.Application.Features.CargoRequests.Requests.Commands;
using Hann.Application.CargoManager.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.Features.CargoRequests.Handlers.Commands
{
    public class DeleteCargoRequestCommandHandler : IRequestHandler<DeleteCargoRequestCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCargoRequestCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCargoRequestCommand request, CancellationToken cancellationToken)
        {
            var vehicleAllocation = await _unitOfWork.CargoRequestRepository.GetAsync(request.Id);

            if (vehicleAllocation == null)
                throw new NotFoundException(nameof(vehicleAllocation), request.Id);

            await _unitOfWork.CargoRequestRepository.DeleteAsync(vehicleAllocation);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}

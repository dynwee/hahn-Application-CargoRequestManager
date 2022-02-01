using Hann.Application.CargoManager.Application.Exceptions;
using Hann.Application.CargoManager.Application.Features.Terminals.Requests.Commands;
using Hann.Application.CargoManager.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.Features.Terminals.Handlers.Commands
{
    public class DeleteTerminalCommandHandler : IRequestHandler<DeleteTerminalCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTerminalCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteTerminalCommand request, CancellationToken cancellationToken)
        {
            var vehicleAllocation = await _unitOfWork.TerminalRepository.GetAsync(request.Id);

            if (vehicleAllocation == null)
                throw new NotFoundException(nameof(vehicleAllocation), request.Id);
            
            await _unitOfWork.TerminalRepository.DeleteAsync(vehicleAllocation);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}

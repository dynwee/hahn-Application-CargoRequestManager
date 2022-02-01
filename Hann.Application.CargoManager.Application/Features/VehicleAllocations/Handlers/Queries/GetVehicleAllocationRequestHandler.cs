using AutoMapper;
using Hann.Application.CargoManager.Application.DTOs.VehicleAllocations;
using Hann.Application.CargoManager.Application.Features.VehicleAllocations.Requests.Queries;
using Hann.Application.CargoManager.Application.Features.VehicleTypes.Requests.Queries;
using Hann.Application.CargoManager.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.Features.VehicleAllocations.Handlers.Queries
{
    public class GetVehicleAllocationRequestHandler : IRequestHandler<GetVehicleAllocationRequest, VehicleAllocationDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetVehicleAllocationRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<VehicleAllocationDto> Handle(GetVehicleAllocationRequest request, CancellationToken cancellationToken)
        {
            var vehicleAllocation = await _unitOfWork.VehicleAllocationRespository.GetAsync(request.Id);

            return _mapper.Map<VehicleAllocationDto>(vehicleAllocation);
        }
    }
}

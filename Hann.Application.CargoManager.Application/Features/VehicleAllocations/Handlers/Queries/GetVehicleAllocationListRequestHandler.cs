using AutoMapper;
using Hann.Application.CargoManager.Application.DTOs.VehicleAllocations;
using Hann.Application.CargoManager.Application.Features.VehicleAllocations.Requests.Queries;
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
    public class GetVehicleAllocationListRequestHandler : IRequestHandler<GetVehicleAllocationListRequest, List<VehicleAllocationDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetVehicleAllocationListRequestHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<VehicleAllocationDto>> Handle(GetVehicleAllocationListRequest request, CancellationToken cancellationToken)
        {
            var vehicleAllocationResp = await _unitOfWork.VehicleAllocationRespository.GetAllAsync();
            return _mapper.Map<List<VehicleAllocationDto>>(vehicleAllocationResp);
        }
    }
}

using AutoMapper;
using Hann.Application.CargoManager.Application.DTOs.VehicleTypes;
using Hann.Application.CargoManager.Application.Features.VehicleTypes.Requests.Queries;
using Hann.Application.CargoManager.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.Features.VehicleTypes.Handlers.Queries
{
    public class GetVehicleTypeListRequestHandler : IRequestHandler<GetVehicleTypeListRequest, List<VehicleTypeDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetVehicleTypeListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<VehicleTypeDto>> Handle(GetVehicleTypeListRequest request, CancellationToken cancellationToken)
        {
            var vehicleTypeList = await _unitOfWork.VehicleTypeRepository.GetAllAsync();
            return _mapper.Map<List<VehicleTypeDto>>(vehicleTypeList);
        }
    }
}

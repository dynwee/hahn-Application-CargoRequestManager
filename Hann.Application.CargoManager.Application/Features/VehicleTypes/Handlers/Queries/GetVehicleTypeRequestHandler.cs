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
    public class GetVehicleTypeRequestHandler : IRequestHandler<GetVehicleTypeRequest, VehicleTypeDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetVehicleTypeRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<VehicleTypeDto> Handle(GetVehicleTypeRequest request, CancellationToken cancellationToken)
        {
            var vehicleType = await _unitOfWork.VehicleTypeRepository.GetAsync(request.Id);
            return _mapper.Map<VehicleTypeDto>(vehicleType);
        }
    }
}

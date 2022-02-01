using AutoMapper;
using Hann.Application.CargoManager.Application.Contracts.Persistence;
using Hann.Application.CargoManager.Application.DTOs.CargoRequests;
using Hann.Application.CargoManager.Application.Features.CargoRequests.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.Features.CargoRequests.Handlers.Queries
{
    public class GetCargoRequestDetailHandler : IRequestHandler<GetCargoRequestDetails, CargoRequestDetailsDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCargoRequestDetailHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CargoRequestDetailsDto> Handle(GetCargoRequestDetails request, CancellationToken cancellationToken)
        {
            var cargoRequest = await _unitOfWork.CargoRequestRepository.GetCargoRequestDetails(request.Id);
            return _mapper.Map<CargoRequestDetailsDto>(cargoRequest);
        }
    }
}

using AutoMapper;
using Hann.Application.CargoManager.Application.DTOs.CargoRequests;
using Hann.Application.CargoManager.Application.Features.CargoRequests.Requests.Queries;
using Hann.Application.CargoManager.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.Features.CargoRequests.Handlers.Queries
{
    public class GetCargoRequestHandler : IRequestHandler<GetCargoRequest, CargoRequestDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCargoRequestHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CargoRequestDto> Handle(GetCargoRequest request, CancellationToken cancellationToken)
        {
            var cargoRequest = await _unitOfWork.CargoRequestRepository.GetAsync(request.Id);
            return _mapper.Map<CargoRequestDto>(cargoRequest);
        }
    }
}

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
    public class GetCargoRequestListHandler : IRequestHandler<GetCargoRequestList, List<CargoRequestDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCargoRequestListHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<CargoRequestDto>> Handle(GetCargoRequestList request, CancellationToken cancellationToken)
        {
            var cargoRequests = await _unitOfWork.CargoRequestRepository.GetAllAsync();
            return _mapper.Map<List<CargoRequestDto>>(cargoRequests);
        }
    }
}

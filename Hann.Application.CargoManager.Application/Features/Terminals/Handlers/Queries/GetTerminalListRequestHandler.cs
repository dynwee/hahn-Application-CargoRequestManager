using AutoMapper;
using Hann.Application.CargoManager.Application.DTOs.Terminals;
using Hann.Application.CargoManager.Application.Features.Terminals.Requests.Queries;
using Hann.Application.CargoManager.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.Features.Terminals.Handlers.Queries
{
    public class GetTerminalListRequestHandler : IRequestHandler<GetTerminalListRequest, List<TerminalDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTerminalListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<TerminalDto>> Handle(GetTerminalListRequest request, CancellationToken cancellationToken)
        {
            var terminalResponse = await _unitOfWork.TerminalRepository.GetAllAsync();
            return _mapper.Map<List<TerminalDto>>(terminalResponse);
        }
    }
}

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
    public class GetTerminalRequestHandler : IRequestHandler<GetTerminalRequest, TerminalDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTerminalRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TerminalDto> Handle(GetTerminalRequest request, CancellationToken cancellationToken)
        {
            var terminal = await _unitOfWork.TerminalRepository.GetAsync(request.Id);
            return _mapper.Map<TerminalDto>(terminal);
        }

    }
}

using AutoMapper;
using Hann.Application.CargoManager.Application.DTOs.Terminals.Validators;
using Hann.Application.CargoManager.Application.Features.Terminals.Requests.Commands;
using Hann.Application.CargoManager.Application.Contracts.Persistence;
using Hann.Application.CargoManager.Application.Responses;
using Hann.Application.CargoManager.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.Features.Terminals.Handlers.Commands
{
    public class CreateTerminalCommandHandler : IRequestHandler<CreateTerminalComand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTerminalCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTerminalComand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTerminalDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateTerminalDto);

            if(validationResult.IsValid == false)
            {
                response.IsSuccess = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            var terminal = _mapper.Map<Terminal>(request.CreateTerminalDto);
            terminal.IsActive = true;

            terminal = await _unitOfWork.TerminalRepository.AddAsync(terminal);
            await _unitOfWork.Save();

            response.IsSuccess = true;
            response.Message = "Creation Successful";
            response.Id = terminal.Id;

            return response;
        }
    }
}

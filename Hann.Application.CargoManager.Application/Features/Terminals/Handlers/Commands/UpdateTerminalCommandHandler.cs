using AutoMapper;
using Hann.Application.CargoManager.Application.DTOs.Terminals.Validators;
using Hann.Application.CargoManager.Application.Features.Terminals.Requests.Commands;
using Hann.Application.CargoManager.Application.Contracts.Persistence;
using Hann.Application.CargoManager.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.Features.Terminals.Handlers.Commands
{
    public class UpdateTerminalCommandHandler : IRequestHandler<UpdateTerminalCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTerminalCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateTerminalCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new UpdateTerminalDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateTerminalDto);

            if (validationResult.IsValid == false)
            {
                response.IsSuccess = false;
                response.Message = "Update Failed";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            var terminal = await _unitOfWork.TerminalRepository.GetAsync(request.UpdateTerminalDto.Id);
            _mapper.Map(request.UpdateTerminalDto, terminal);

            await _unitOfWork.TerminalRepository.UpdateAsync(terminal);

            await _unitOfWork.Save();

            response.IsSuccess = true;
            response.Message = "Update Successful";
            response.Id = terminal.Id;


            return response;
        }
    }
}

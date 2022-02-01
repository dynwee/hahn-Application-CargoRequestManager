using AutoMapper;
using Hann.Application.CargoManager.Application.DTOs.CargoRequests.Validators;
using Hann.Application.CargoManager.Application.Exceptions;
using Hann.Application.CargoManager.Application.Features.CargoRequests.Requests.Commands;
using Hann.Application.CargoManager.Application.Contracts.Persistence;
using Hann.Application.CargoManager.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.Features.CargoRequests.Handlers.Commands
{
    public class UpdateCargoRequestCommandHandler : IRequestHandler<UpdateCargoRequestCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCargoRequestCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(UpdateCargoRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var cargoRequest = await _unitOfWork.CargoRequestRepository.GetAsync(request.Id);

            if (request.UpdateCargoRequestDto != null)
            {
                var validator = new UpdateCargoRequestValidator(_unitOfWork.TerminalRepository);
                var validationResult = await validator.ValidateAsync(request.UpdateCargoRequestDto);

                if (validationResult.IsValid == false)
                {
                    response.IsSuccess = false;
                    response.Message = "Update Failed";
                    response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                    return response;
                }

                _mapper.Map(request.UpdateCargoRequestDto, cargoRequest);

                await _unitOfWork.CargoRequestRepository.UpdateAsync(cargoRequest);
                await _unitOfWork.Save();

                response.IsSuccess = true;
                response.Message = "Update Successful";
                response.Id = cargoRequest.Id;
                return response;
            }
            else if (request.ChangeCargoRequestStatusDto != null)
            {
                await _unitOfWork.CargoRequestRepository.ChangeApprovalStatus(cargoRequest, request.ChangeCargoRequestStatusDto.Status);
                await _unitOfWork.Save();

                response.IsSuccess = true;
                response.Message = "Update status Successful";
                response.Id = cargoRequest.Id;
                return response;
            }

            return response;

        }
    }
}

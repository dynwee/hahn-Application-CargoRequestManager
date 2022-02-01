using AutoMapper;
using Hann.Application.CargoManager.Application.DTOs.CargoRequests.Validators;
using Hann.Application.CargoManager.Application.Features.CargoRequests.Requests.Commands;
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
using Hann.Application.CargoManager.Application.Contracts.Infrastructure;

namespace Hann.Application.CargoManager.Application.Features.CargoRequests.Handlers.Commands
{
    public class CreateCargoRequestCommandHandler : IRequestHandler<CreateCargoRequestCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public CreateCargoRequestCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailSender = emailSender;
        }

        public async Task<BaseCommandResponse> Handle(CreateCargoRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new CreateCargoRequestDtoValidator(_unitOfWork.TerminalRepository);
            var ValidationResult = await validator.ValidateAsync(request.CreateCargoRequestDto);
            if (ValidationResult.IsValid == false)
            {
                response.IsSuccess = false;
                response.Message = "Creation Failed";
                response.Errors = ValidationResult.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            var cargoRequest = _mapper.Map<CargoRequest>(request.CreateCargoRequestDto);
            cargoRequest.Status = "Pending";
            await _unitOfWork.CargoRequestRepository.AddAsync(cargoRequest);
            await _unitOfWork.Save();

            response.IsSuccess = true;
            response.Message = "Creation Successful";
            response.Id = cargoRequest.Id;

            await SendRequestAcknwoledgementEmail();

            return response;
        }

        private async Task SendRequestAcknwoledgementEmail()
        {
            var emailDetails = new Models.Email.Email
            {
                To = "onwudiweokeke@gmail.com",
                Body = $"Your Cargo request has been recieved. Will update you by email as we process your request.",
                Subject = "Cargo Request Acknowledgement"
            };

            try
            {
                await _emailSender.SendEmail(emailDetails);
            }
            catch (Exception ex)
            {
                //log error;
            }
        }
    }
}

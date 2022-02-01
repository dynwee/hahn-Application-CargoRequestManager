using AutoMapper;
using Hann.Application.CargoManager.Application.DTOs.VehicleTypes.Validators;
using Hann.Application.CargoManager.Application.Features.VehicleTypes.Requests.Commands;
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

namespace Hann.Application.CargoManager.Application.Features.VehicleTypes.Handlers.Commands
{
    public class CreateVehicleTypeCommandHandler : IRequestHandler<CreateVehicleTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateVehicleTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateVehicleTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateVehicleTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateVehicleTypeDto);

            if (validationResult.IsValid == false)
            {
                response.IsSuccess = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            var vehicleType = _mapper.Map<VehicleType>(request.CreateVehicleTypeDto);

            vehicleType = await _unitOfWork.VehicleTypeRepository.AddAsync(vehicleType);
            await _unitOfWork.Save();

            response.IsSuccess = true;
            response.Message = "Creation Successful";
            response.Id = vehicleType.Id;

            return response;
        }
    
    }
}

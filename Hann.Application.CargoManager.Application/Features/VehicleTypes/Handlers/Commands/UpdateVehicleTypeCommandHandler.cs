using AutoMapper;
using Hann.Application.CargoManager.Application.DTOs.VehicleTypes.Validators;
using Hann.Application.CargoManager.Application.Features.VehicleTypes.Requests.Commands;
using Hann.Application.CargoManager.Application.Contracts.Persistence;
using Hann.Application.CargoManager.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.Features.VehicleTypes.Handlers.Commands
{
    public class UpdateVehicleTypeCommandHandler : IRequestHandler<UpdateVehicleTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateVehicleTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateVehicleTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new UpdateVehicleTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateVehicleTypeDto);

            if (validationResult.IsValid == false)
            {
                response.IsSuccess = false;
                response.Message = "Update Failed";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            var vehicleType = await _unitOfWork.VehicleTypeRepository.GetAsync(request.UpdateVehicleTypeDto.Id);
            _mapper.Map(request.UpdateVehicleTypeDto, vehicleType);

            await _unitOfWork.VehicleTypeRepository.UpdateAsync(vehicleType);
            await _unitOfWork.Save();

            response.IsSuccess = true;
            response.Message = "Update Successful";
            response.Id = vehicleType.Id;

            return response;
        }
    }
}

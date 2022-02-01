using AutoMapper;
using Hann.Application.CargoManager.Application.DTOs.VehicleAllocations.Validators;
using Hann.Application.CargoManager.Application.Features.VehicleAllocations.Requests.Commands;
using Hann.Application.CargoManager.Application.Contracts.Persistence;
using Hann.Application.CargoManager.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.Features.VehicleAllocations.Handlers.Commands
{
    public class UpdateVehicleAllocationCommandHandler : IRequestHandler<UpdateVehicleAllocationCommand,BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateVehicleAllocationCommandHandler(IMapper mapper,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle(UpdateVehicleAllocationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new UpdateVehicleAllocationDtoValidator(_unitOfWork.VehicleTypeRepository, _unitOfWork.CargoRequestRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateVehicleAllocationDto);

            if (validationResult.IsValid == false)
            {
                response.IsSuccess = false;
                response.Message = "Update Failed";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            var vehicleAllocation = await _unitOfWork.VehicleAllocationRespository.GetAsync(request.UpdateVehicleAllocationDto.Id);
            _mapper.Map(request.UpdateVehicleAllocationDto, vehicleAllocation);

            var cargoRequest = await _unitOfWork.CargoRequestRepository.GetAsync(request.UpdateVehicleAllocationDto.CargoRequestId);
            await _unitOfWork.VehicleAllocationRespository.UpdateAsync(vehicleAllocation);

            await _unitOfWork.CargoRequestRepository.ChangeApprovalStatus(cargoRequest, "Assign");

            await _unitOfWork.Save();



            response.IsSuccess = true;
            response.Message = "Update Successful";
            response.Id = vehicleAllocation.Id;

            return response;
        }
    }
}

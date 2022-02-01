using AutoMapper;
using Hann.Application.CargoManager.Application.DTOs.VehicleAllocations.Validators;
using Hann.Application.CargoManager.Application.Features.VehicleAllocations.Requests.Commands;
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

namespace Hann.Application.CargoManager.Application.Features.VehicleAllocations.Handlers.Commands
{
    public class CreateVehicleAllocationCommandHandler : IRequestHandler<CreateVehicleAllocationCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateVehicleAllocationCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateVehicleAllocationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateVehicleAllocationDtoValidator(_unitOfWork.VehicleTypeRepository, _unitOfWork.CargoRequestRepository);
            var validationResult = await validator.ValidateAsync(request.CreateVehicleAllocationDto);

            if(validationResult.IsValid ==  false)
            {
                response.IsSuccess = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            var vehicleAllocation = _mapper.Map<VehicleAllocation>(request.CreateVehicleAllocationDto);

            vehicleAllocation = await _unitOfWork.VehicleAllocationRespository.AddAsync(vehicleAllocation);

            response.IsSuccess = true;
            response.Message = "Creation Successful";
            response.Id = vehicleAllocation.Id;

            return response;
        }
    }
}

using Hann.Application.CargoManager.Application.DTOs.VehicleAllocations;
using Hann.Application.CargoManager.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.Features.VehicleAllocations.Requests.Commands
{
    public class UpdateVehicleAllocationCommand : IRequest<BaseCommandResponse>
    {
        public UpdateVehicleAllocationDto UpdateVehicleAllocationDto { get; set; }
    }
}

using Hann.Application.CargoManager.Application.DTOs.VehicleAllocations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.Features.VehicleAllocations.Requests.Queries
{
    public class GetVehicleAllocationListRequest : IRequest<List<VehicleAllocationDto>>
    {
    }
}

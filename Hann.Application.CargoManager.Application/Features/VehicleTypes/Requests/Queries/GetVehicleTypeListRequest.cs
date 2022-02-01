using Hann.Application.CargoManager.Application.DTOs.VehicleTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.Features.VehicleTypes.Requests.Queries
{
    public class GetVehicleTypeListRequest : IRequest<List<VehicleTypeDto>>
    {
    }
}

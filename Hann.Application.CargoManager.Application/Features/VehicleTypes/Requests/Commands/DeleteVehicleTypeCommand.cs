using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.Features.VehicleTypes.Requests.Commands
{
    public class DeleteVehicleTypeCommand : IRequest
    {
        public int Id { get; set; }
    }
}

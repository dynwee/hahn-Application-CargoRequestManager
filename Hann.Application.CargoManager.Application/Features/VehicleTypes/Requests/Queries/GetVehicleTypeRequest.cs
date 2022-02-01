using Hann.Application.CargoManager.Application.DTOs.VehicleTypes;
using MediatR;

namespace Hann.Application.CargoManager.Application.Features.VehicleTypes.Requests.Queries
{
    public class GetVehicleTypeRequest : IRequest<VehicleTypeDto>
    {
        public int Id { get; set; }
    }
}

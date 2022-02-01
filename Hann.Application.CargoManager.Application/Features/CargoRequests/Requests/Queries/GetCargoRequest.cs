using Hann.Application.CargoManager.Application.DTOs.CargoRequests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.Features.CargoRequests.Requests.Queries
{
    public class GetCargoRequest : IRequest<CargoRequestDto>
    {
        public int Id { get; set; }
    }
}

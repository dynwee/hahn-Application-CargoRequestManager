using Hann.Application.CargoManager.Application.DTOs.CargoRequests;
using Hann.Application.CargoManager.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.Features.CargoRequests.Requests.Commands
{
    public class CreateCargoRequestCommand : IRequest<BaseCommandResponse>
    {
        public CreateCargoRequestDto CreateCargoRequestDto { get; set; }
    }
}

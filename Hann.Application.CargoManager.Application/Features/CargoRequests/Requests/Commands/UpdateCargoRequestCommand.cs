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
    public class UpdateCargoRequestCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
        public ChangeCargoRequestStatusDto ChangeCargoRequestStatusDto { get; set; }
        public UpdateCargoRequestDto UpdateCargoRequestDto { get; set; }
    }
}

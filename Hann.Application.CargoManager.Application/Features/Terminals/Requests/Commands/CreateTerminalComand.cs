using Hann.Application.CargoManager.Application.DTOs.Terminals;
using Hann.Application.CargoManager.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.Features.Terminals.Requests.Commands
{
    public class CreateTerminalComand : IRequest<BaseCommandResponse>
    {
        public CreateTerminalDto CreateTerminalDto { get; set; }
    }
}

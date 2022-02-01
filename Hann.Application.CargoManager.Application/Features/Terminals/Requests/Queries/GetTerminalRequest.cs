using Hann.Application.CargoManager.Application.DTOs.Terminals;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.Features.Terminals.Requests.Queries
{
    public class GetTerminalRequest : IRequest<TerminalDto>
    {
        public int Id { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.Features.CargoRequests.Requests.Commands
{
    public class DeleteCargoRequestCommand : IRequest
    {
        public int Id { get; set; }
    }
}

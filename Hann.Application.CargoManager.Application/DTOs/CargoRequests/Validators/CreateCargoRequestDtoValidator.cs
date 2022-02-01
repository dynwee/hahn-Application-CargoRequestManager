using FluentValidation;
using Hann.Application.CargoManager.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.DTOs.CargoRequests.Validators
{
    public class CreateCargoRequestDtoValidator : AbstractValidator<CreateCargoRequestDto>
    {
        private readonly ITerminalRepository _terminalRepository;
        public CreateCargoRequestDtoValidator(ITerminalRepository terminalRepository)
        {
            _terminalRepository = terminalRepository;

            Include(new ICargoRequestValidator(_terminalRepository));
        }
    }
}

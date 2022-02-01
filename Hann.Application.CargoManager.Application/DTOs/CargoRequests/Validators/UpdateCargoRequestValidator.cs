using FluentValidation;
using Hann.Application.CargoManager.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.DTOs.CargoRequests.Validators
{
    public class UpdateCargoRequestValidator : AbstractValidator<UpdateCargoRequestDto>
    {
        private readonly ITerminalRepository _terminalRepository;
        public UpdateCargoRequestValidator(ITerminalRepository terminalRepository)
        {
            _terminalRepository = terminalRepository;

            Include(new ICargoRequestValidator(_terminalRepository));
            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

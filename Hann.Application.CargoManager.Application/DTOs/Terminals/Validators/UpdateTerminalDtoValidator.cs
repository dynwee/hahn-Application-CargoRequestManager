using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.DTOs.Terminals.Validators
{
    public class UpdateTerminalDtoValidator : AbstractValidator<UpdateTerminalDto>
    {
        public UpdateTerminalDtoValidator()
        {
            Include(new ITerminalDtoValidator());
            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.DTOs.Terminals.Validators
{
    public class CreateTerminalDtoValidator :  AbstractValidator<CreateTerminalDto>
    {
        public CreateTerminalDtoValidator()
        {
            Include(new ITerminalDtoValidator());
        }
    }
}

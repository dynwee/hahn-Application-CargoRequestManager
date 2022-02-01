using Hann.Application.CargoManager.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.DTOs.Terminals
{
    public class TerminalDto : BaseDto, ITerminalDto
    {
        public string TerminalName { get; set; }
        public string TerminalAddress { get; set; }
        public string TerminalContactNo { get; set; }
        public string EmailAddress { get; set; }
        public string WebsiteAddress { get; set; }
        public bool IsActive { get; set; }
    }
}

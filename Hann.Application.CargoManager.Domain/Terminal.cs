using Hann.Application.CargoManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Domain
{
    public class Terminal : BaseDomainEntity
    {
        public string TerminalName { get; set; }
        public string TerminalAddress { get; set; }
        public string TerminalContactNo{ get; set; }
        public string WebsiteAddress { get; set; }
        public string EmailAddress { get; set; }
        public bool IsActive { get; set; }
    }
}

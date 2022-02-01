using Hann.Application.CargoManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Domain
{
    public class VehicleType : BaseDomainEntity
    {
        public string VehicleTypeName { get; set; }
        public bool IsActive { get; set; }
    }
}

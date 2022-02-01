using Hann.Application.CargoManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Domain
{
    public class VehicleAllocation : BaseDomainEntity
    {
        public VehicleType VehicleType { get; set; }
        public int VehicleTypeId { get; set; }
        public CargoRequest CargoRequest { get; set; }
        public int CargoRequestId { get; set; }
        public bool InUse { get; set; }
    }

}

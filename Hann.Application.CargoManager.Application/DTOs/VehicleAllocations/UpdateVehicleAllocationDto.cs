using Hann.Application.CargoManager.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.DTOs.VehicleAllocations
{
    public class UpdateVehicleAllocationDto : BaseDto, IVehicleAllocationDto
    {
        public int VehicleTypeId { get; set; }
        public int CargoRequestId { get; set; }
        public bool InUse { get; set; }
    }
}

using Hann.Application.CargoManager.Application.DTOs.CargoRequests;
using Hann.Application.CargoManager.Application.DTOs.Common;
using Hann.Application.CargoManager.Application.DTOs.VehicleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.DTOs.VehicleAllocations
{
    public class VehicleAllocationDto : BaseDto, IVehicleAllocationDto
    {
        public VehicleTypeDto VehicleType { get; set; }
        public int VehicleTypeId { get; set; }
        public CargoRequestDto CargoRequest { get; set; }
        public int CargoRequestId { get; set; }
        public bool InUse { get; set; }
    }
}

using Hann.Application.CargoManager.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.DTOs.VehicleTypes
{
    public class UpdateVehicleTypeDto : BaseDto, IVehicleTypeDto
    {
        public string VehicleTypeName { get; set; }
        public bool IsActive { get; set; }
    }
}

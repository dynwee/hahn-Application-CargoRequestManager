using Hann.Application.CargoManager.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.DTOs.CargoRequests
{
    public class ChangeCargoRequestStatusDto : BaseDto
    {
        public string Status { get; set; }
    }
}

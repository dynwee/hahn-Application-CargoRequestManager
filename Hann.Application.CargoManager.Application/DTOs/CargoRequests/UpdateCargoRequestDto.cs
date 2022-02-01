using Hann.Application.CargoManager.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.DTOs.CargoRequests
{
    public class UpdateCargoRequestDto : BaseDto, ICargoRequestDto
    {
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public int DropOffTerminalId { get; set; }
        public DateTime DropOffDate { get; set; }
        public int DeliveryTerminalId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string EstimatedWeight { get; set; }
        public string ItemSummary { get; set; }
        public string ItemDescription { get; set; }
        public string Status { get; set; }
    }
}

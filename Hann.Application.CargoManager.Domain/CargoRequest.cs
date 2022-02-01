using Hann.Application.CargoManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Domain
{
    public class CargoRequest : BaseDomainEntity
    {
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public Terminal DropOffTerminal { get; set; }
        public int DropOffTerminalId { get; set; }
        public DateTime DropOffDate { get; set; }
        public Terminal DeliveryTerminal { get; set; }
        public int DeliveryTerminalId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string EstimatedWeight { get; set; }
        public string ItemSummary { get; set; }
        public string ItemDescription { get; set; }
        public string Status { get; set; }
    }
}

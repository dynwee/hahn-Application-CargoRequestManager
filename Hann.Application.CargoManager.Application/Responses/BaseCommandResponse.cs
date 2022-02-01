using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.Responses
{
    public class BaseCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int Id { get; set; }
        public List<string> Errors { get; set; }
    }
}

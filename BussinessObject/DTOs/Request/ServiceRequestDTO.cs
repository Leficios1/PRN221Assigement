using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DTOs.Request
{
    public class ServiceRequestDTO
    {
        public int Id { get; set; }
        public string ServiceName { get; set; } = null!;
        public decimal ServiceCharge { get; set; }

    }
}

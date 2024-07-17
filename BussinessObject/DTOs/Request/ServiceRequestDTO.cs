using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DTOs.Request
{
    public class ServiceRequestDTO
    {
        public int Id { get; set; }
        public string ServiceName { get; set; } = null!;

        [Required(ErrorMessage = "Service Charge is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Service Charge must be greater than zero")]
        public decimal ServiceCharge { get; set; }

    }
}

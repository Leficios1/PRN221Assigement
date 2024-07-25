using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DTOs.Response
{
    public class CheckOutResponese
    {
        public string UserName { get; set; } = null!;
        public string PetName { get; set; } = null!;
        public string ServiceName { get; set; } = null!;
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

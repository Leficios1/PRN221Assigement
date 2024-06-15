using BussinessObject.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DTOs.Request
{
    public class BookingRequestDTO
    {
        public int BookingId { get; set; } = 0;
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
        public string? Note { get; set; }
        public List<BookingDetailsRequestDTO> bookingDetails { get; set; }
    }
    public class BookingDetailsRequestDTO
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int VetId { get; set; }
        public int ServiceId { get; set; }
        public decimal Price { get; set; }
        public int Status { get; set; }
    }
}

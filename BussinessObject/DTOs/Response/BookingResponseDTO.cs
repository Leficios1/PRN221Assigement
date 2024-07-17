using BussinessObject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DTOs.Response
{
    public class BookingResponseDTO
    {
        public int BookingId { get; set; }
        public string UserName { get; set; } = null!;
        public DateTime Date { get; set; }
        public int Status { get; set; }
        public string? Note { get; set; }
        public List<BookingDetailsDTO>? bookingDetails {  get; set; }
    }

    public class BookingDetailsDTO
    {
        public int Id { get; set; }
        public string PetName { get; set; } = null!;
        public string VetName { get; set; }
        public string ServiceName { get; set; } = null!;
        public decimal Price { get; set; }
        public int Status { get; set; }
        public string? KennelName { get; set; }
    }
}

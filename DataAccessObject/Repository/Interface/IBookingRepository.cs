using BussinessObject.DTOs.Request;
using BussinessObject.DTOs.Response;
using BussinessObject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Repository.Interface
{
    public interface IBookingRepository : IBaseRepository<Booking>
    {
        public Task<BookingResponseDTO> getAllBookingAsync();
        public Task<BookingResponseDTO> updateBookingAsync(BookingRequestDTO dto);
        public Task<bool> deleteBookingAsync(int id);
        public Task<bool> createBooking(BookingRequestDTO dto);
        public Task<BookingResponseDTO> getById(int id);
    }
}

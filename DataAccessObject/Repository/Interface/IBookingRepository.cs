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
        public Task<List<Booking>> getAllBookingAsync();
        public Task<BookingResponseDTO> updateBookingAsync(BookingRequestDTO dto);
        public Task<bool> deleteBookingAsync(int id);
        public Task<bool> createBooking(BookingRequestDTO dto);
        public Task<BookingResponseDTO> getById(int id);
        public Task<List<DateTime>> getDateTimeBookingByVetId(int vetId);
        public Task<List<Booking>> getBookingByUserId(int userId);
        public Task<List<Booking>> getAllBookingByVetId(int vetId);
        public Task<List<Booking>> getNewBookingByVetId(int vetId);
        
    }
}

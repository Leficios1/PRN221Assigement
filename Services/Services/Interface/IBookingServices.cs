using BussinessObject.DTOs.Request;
using BussinessObject.DTOs.Response;
using BussinessObject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interface
{
    public interface IBookingServices
    {
        Task<bool> createBooking(BookingRequestDTO dto);
        Task<BookingResponseDTO> getBookingDetailsByBookingId(int id);
        Task<List<BookingResponseDTO>> getAllBookingAsync();
        Task<List<BookingResponseDTO>> getBookingByUserId(int id);
        Task<List<BookingResponseDTO>> getAllBookingByVetId(int vetId);
        Task<List<BookingResponseDTO>> getNewBookingByVetId(int vetId);
        Task<bool> updateStatus(int bookingId);
        Task<int> countBooking();
        Task<List<int>> BookingPerDays();
    }
}

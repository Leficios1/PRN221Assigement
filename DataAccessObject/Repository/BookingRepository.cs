using AutoMapper;
using BussinessObject.DTOs.Request;
using BussinessObject.DTOs.Response;
using BussinessObject.Model.Entities;
using DataAccessObject.Database;
using DataAccessObject.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Repository
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        private readonly PetManagementContext _context;
        private readonly IMapper _mapper;
        public BookingRepository(PetManagementContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> createBooking(BookingRequestDTO dto)
        {
            using(var trasaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if(dto.BookingId != 0)
                    {
                        throw new Exception("Do not Input ID when create");
                    }
                    var data = _mapper.Map<Booking>(dto);
                    _context.Bookings.Add(data);
                    await _context.SaveChangesAsync();
                    foreach(var details in dto.bookingDetails)
                    {
                        if(await _context.Vets.Where(x => x.Id == details.VetId).SingleOrDefaultAsync() == null ||
                            await _context.Services.Where(x => x.Id == details.ServiceId).SingleOrDefaultAsync() == null)
                        {
                            return false;
                        }
                        var result = _mapper.Map<BookingDetails>(details);
                        result.BookingId = data.BookingId;
                        _context.BookingDetails.Add(result);
                    }
                    await _context.SaveChangesAsync();
                    await trasaction.CommitAsync();
                    return true;
                }catch (Exception ex)
                {
                    await trasaction.RollbackAsync();
                    throw new Exception(ex.Message);
                }
            }
        }

        public Task<bool> deleteBookingAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BookingResponseDTO> getAllBookingAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BookingResponseDTO> getById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BookingResponseDTO> updateBookingAsync(BookingRequestDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}

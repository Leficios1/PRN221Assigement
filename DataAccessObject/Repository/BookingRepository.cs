using AutoMapper;
using BussinessObject.DTOs.Request;
using BussinessObject.DTOs.Response;
using BussinessObject.Model.Entities;
using BussinessObject.Model.ENUM;
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
            using (var trasaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (dto.BookingId != 0)
                    {
                        throw new Exception("Do not Input ID when create");
                    }
                    var data = new Booking();
                    data.Date = dto.Date;
                    data.UserId = dto.UserId;
                    data.Status = (int)StatusEnum.active;
                    data.Note = dto.Note;
                    _context.Bookings.Add(data);
                    await _context.SaveChangesAsync();

                    foreach (var details in dto.bookingDetails)
                    {
                        if (await _context.Vets.Where(x => x.Id == details.VetId).FirstOrDefaultAsync() == null ||
                            await _context.Services.Where(x => x.Id == details.ServiceId).FirstOrDefaultAsync() == null)
                        {
                            return false;
                        }
                        var result = _mapper.Map<BookingDetails>(details);
                        result.BookingId = data.BookingId;
                        result.Price = (await _context.Services.Where(x => x.Id == details.ServiceId).SingleOrDefaultAsync()).ServiceCharge;
                        result.Status = (int)StatusEnum.active;
                        _context.BookingDetails.Add(result);
                    }
                    await _context.SaveChangesAsync();
                    await trasaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
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

        public async Task<List<Booking>> getAllBookingAsync()
        {
            var data = await _context.Bookings
        .Include(b => b.User)  // Include User information
        .Include(b => b.BookingDetails)
            .ThenInclude(d => d.Pet)
        .Include(b => b.BookingDetails)
            .ThenInclude(d => d.vet)
        .Include(b => b.BookingDetails)
            .ThenInclude(d => d.service)
        .ToListAsync(); ;
            return data;
        }

        public async Task<BookingResponseDTO> getById(int id)
        {
            var booking = await _context.Bookings
                       .Include(b => b.User)
                       .Include(b => b.BookingDetails)
                           .ThenInclude(d => d.Pet)
                       .Include(b => b.BookingDetails)
                           .ThenInclude(d => d.vet)
                       .Include(b => b.BookingDetails)
                           .ThenInclude(d => d.service)
                       .FirstOrDefaultAsync(b => b.BookingId == id);

            if (booking == null)
            {
                throw new Exception("Not found bookingId");
            }

            var bookingDTO = _mapper.Map<BookingResponseDTO>(booking);
            bookingDTO.bookingDetails = _mapper.Map<List<BookingDetailsDTO>>(booking.BookingDetails);

            return bookingDTO;
        }

        public async Task<List<DateTime>> getDateTimeBookingByVetId(int vetId)
        {
            return await _context.BookingDetails
                        .Where(b => b.VetId == vetId)
                        .Select(b => b.booking.Date)
                        .ToListAsync();
        }

        public Task<BookingResponseDTO> updateBookingAsync(BookingRequestDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}

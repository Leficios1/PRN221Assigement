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
                    data.Status = (int)StatusEnum.inProcess;
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
        .ToListAsync();
            return data;
        }
        public async Task<List<Booking>> getAllBookingProcessAsync()
        {
            var data = await _context.Bookings
        .Include(b => b.User)  // Include User information
        .Include(b => b.BookingDetails)
            .ThenInclude(d => d.Pet)
        .Include(b => b.BookingDetails)
            .ThenInclude(d => d.vet)
        .Include(b => b.BookingDetails)
            .ThenInclude(d => d.service)
        .Where(b => b.Status == 3).ToListAsync();
            return data;
        }

        public async Task<List<Booking>> getAllBookingDoneAsync()
        {
            var data = await _context.Bookings
        .Include(b => b.User)  // Include User information
        .Include(b => b.BookingDetails)
            .ThenInclude(d => d.Pet)
        .Include(b => b.BookingDetails)
            .ThenInclude(d => d.vet)
        .Include(b => b.BookingDetails)
            .ThenInclude(d => d.service)
        .Where(b => b.Status == 2).ToListAsync();
            return data;
        }

        private async Task<int> getVetIdByVetId(int vetId)
        {
            var name = await _context.Users.Where(u => u.Id == vetId).Select(u => u.Name).SingleOrDefaultAsync();
            if (name == null)
            {
                return 0;
            }
            var id = await _context.Vets.Where(v => v.Name.Equals(name)).Select(v => v.Id).SingleOrDefaultAsync();
            return id;
        }

        public async Task<List<Booking>> getAllBookingByVetId(int vetId)
        {
            var id = await getVetIdByVetId(vetId);
            return await _context.Set<Booking>()
                .Include(b => b.BookingDetails)
                    .ThenInclude(bd => bd.vet)
                .Include(b => b.BookingDetails)
                    .ThenInclude(bd => bd.Pet)
                .Include(b => b.BookingDetails)
                    .ThenInclude(bd => bd.service)
                .Where(b => b.BookingDetails.Any(bd => bd.VetId == id))
                .ToListAsync();
        }

        public async Task<List<Booking>> getBookingByUserId(int userId)
        {
            var data = await _context.Bookings
        .Include(b => b.BookingDetails)
            .ThenInclude(d => d.Pet)
        .Include(b => b.BookingDetails)
            .ThenInclude(d => d.vet)
        .Include(b => b.BookingDetails)
            .ThenInclude(d => d.service)
        .Where(x => x.UserId == userId)
        .ToListAsync();
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

        public async Task<List<Booking>> getNewBookingByVetId(int vetId)
        {
            var id = await getVetIdByVetId(vetId);
            var data = await _context.Set<Booking>()
                .Include(b => b.BookingDetails)
                    .ThenInclude(bd => bd.vet)
                .Include(b => b.BookingDetails)
                    .ThenInclude(bd => bd.Pet)
                .Include(b => b.BookingDetails)
                    .ThenInclude(bd => bd.service)
                .Where(b => b.Date >= DateTime.Now && b.BookingDetails.Any(bd => bd.VetId == id))
                .ToListAsync();
            return data;
        }

        public void updateBookingAsync(Booking entity)
        {
            _context.Bookings.Update(entity);
            _context.SaveChanges();
        }
        public Booking getByIdEntity(int id)
        {
            var book = _context.Bookings.FirstOrDefault(b => b.BookingId == id);
            return book;
        }

        public async Task<bool> updateStatus(int bookingId)
        {
            var data = await _context.Bookings.Where(x => x.BookingId == bookingId).SingleOrDefaultAsync();
            if (data == null)
            {
                return false;
            }
            data.Status = (int)StatusEnum.active;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> countBooking()
        {
            var data = await _context.Bookings
            .CountAsync(b => b.Date.Date == DateTime.Today);
            return data;
        }

        public async Task<List<int>> bookingPerDay()
        {
            var today = DateTime.Today;
            var sevenDaysAgo = today.AddDays(-6);

            var dateRange = Enumerable.Range(0, 7)
                .Select(offset => sevenDaysAgo.AddDays(offset))
                .ToList();

            var bookingCounts = await _context.Bookings
                .Where(b => b.Date.Date >= sevenDaysAgo && b.Date.Date <= today)
                .GroupBy(b => b.Date.Date)
                .Select(g => new { Date = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.Date, x => x.Count);

            var result = dateRange.Select(date => bookingCounts.ContainsKey(date) ? bookingCounts[date] : 0).ToList();

            return result;
        }
    }
}

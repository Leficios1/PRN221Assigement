using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Model.Entities;
using DataAccessObject.Database;
using Services.Services.Interface;
using BussinessObject.DTOs.Response;

namespace AssigmentPRN221.Pages.BookingPage.DetailsPage
{
    public class IndexModel : PageModel
    {
        private readonly IBookingServices _bookingServices;
        private readonly IKennelRecordService _kennelServices;

        public IndexModel(IBookingServices bookingServices, IKennelRecordService kennelServices)
        {
            _bookingServices = bookingServices;
            _kennelServices = kennelServices;        
        }

        public BookingResponseDTO BookingResponseDTO { get; set; }
        public KennelRecordResponseDTO KennelRecordto { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var booking = await _bookingServices.getBookingDetailsByBookingId(id);
            var kennelRecord =  await _kennelServices.getByPetIdDto(booking.bookingDetails.FirstOrDefault().PetId);
            if (booking == null)
            {
                return NotFound();
            }
            BookingResponseDTO = booking;
            KennelRecordto = kennelRecord;
            return Page();
        }
        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}

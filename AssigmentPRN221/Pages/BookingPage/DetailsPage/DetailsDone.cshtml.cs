using BussinessObject.DTOs.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Services.Interface;

namespace AssigmentPRN221.Pages.BookingPage.DetailsPage
{
    public class DetailsDoneModel : PageModel
    {

        private readonly IBookingServices _bookingServices;
        private readonly IKennelRecordService _kennelServices;

        public DetailsDoneModel(IBookingServices bookingServices, IKennelRecordService kennelServices)
        {
            _bookingServices = bookingServices;
            _kennelServices = kennelServices;
        }

        public BookingResponseDTO BookingResponseDTO { get; set; }
        public KennelRecordResponseDTO KennelRecordto { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var booking = await _bookingServices.getBookingDetailsByBookingId(id);
            var kennelRecord = await _kennelServices.getByPetIdDto(booking.bookingDetails.FirstOrDefault().PetId);
            if (booking == null)
            {
                return NotFound();
            }
            BookingResponseDTO = booking;
            if (kennelRecord == null)
            {

            }
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

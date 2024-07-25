using BussinessObject.DTOs.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Services.Interface;

namespace AssigmentPRN221.Pages.BookingPage
{
    public class BookingDoneModel : PageModel
    {
        private readonly IBookingServices _bookingServices;

        public BookingDoneModel(IBookingServices bookingServices)
        {
            _bookingServices = bookingServices;
        }

        public List<BookingResponseDTO> Booking { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Booking = await _bookingServices.getAllBookingDoneAsync();
        }
        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}

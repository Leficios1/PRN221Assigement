using BussinessObject.DTOs.Response;
using DataAccessObject.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Services.Services.Interface;

namespace AssigmentPRN221.Pages.BookingPage
{
    public class CheckOutPageModel : PageModel
    {
        private readonly IBookingServices _bookingServices;
        private readonly IBookingRepository _bookingRepo;

        public CheckOutPageModel(IBookingServices bookingServices, IBookingRepository bookingRepo)
        {
            _bookingServices = bookingServices;
            _bookingRepo = bookingRepo;
            checkout = new CheckOutResponese();
        }

        public BookingResponseDTO Booking { get; set; } = default!;
        public CheckOutResponese checkout { get; set; }

        public async Task OnGetAsync(int id)
        {
            Booking = await _bookingServices.getBookingById(id);
            foreach(var item in Booking.bookingDetails)
            {
                checkout.ServiceName = item.ServiceName;
                checkout.PetName = item.PetName;
                checkout.TotalPrice = item.Price;
            }


        }

        [BindProperty]
        public int BookingId { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var book = _bookingRepo.getByIdEntity(BookingId);
            book.Status = 2;
            _bookingRepo.updateBookingAsync(book);
            return RedirectToPage("./Index");
        }
        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}

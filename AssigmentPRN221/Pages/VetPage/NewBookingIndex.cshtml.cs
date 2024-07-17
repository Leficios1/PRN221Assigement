using BussinessObject.DTOs.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Services.Interface;

namespace AssigmentPRN221.Pages.VetPage
{
    public class NewBookingIndexModel : PageModel
    {
        private readonly IBookingServices _bookingServices;
        private readonly IAccountService _accountService;

        public NewBookingIndexModel(IBookingServices bookingServices, IAccountService accountService)
        {
            _bookingServices = bookingServices;
            _accountService = accountService;
        }

        public List<BookingResponseDTO> NewBookings { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var email = HttpContext.Session.GetString("UserEmail");
            if (email == null)
            {
                return RedirectToPage("/LoginPage");
            }
            var vetId = await _accountService.GetAccountInfoByEmail(email);
            NewBookings = await _bookingServices.getNewBookingByVetId(vetId.Id);
            return Page();
        }
        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}

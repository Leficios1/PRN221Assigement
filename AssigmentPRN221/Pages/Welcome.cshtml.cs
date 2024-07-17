using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Services.Interface;

namespace AssigmentPRN221.Pages
{
    public class WelcomeModel : PageModel
    {
        private readonly IBookingServices _bookingServices;
        private readonly IAccountService _accountService;

        public WelcomeModel(IBookingServices bookingServices, IAccountService accountService)
        {
            _bookingServices = bookingServices;
            _accountService = accountService;
        }

        public int TodayBookingsCount { get; set; }
        public int TotalCustomerAccounts { get; set; }
        public List<string> LastSevenDays { get; set; }
        public List<int> BookingsPerDay { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            var email = HttpContext.Session.GetString("UserEmail");
            if (email == null)
            {
                return RedirectToPage("/LoginPage");
            }
            TodayBookingsCount = await _bookingServices.countBooking();
            TotalCustomerAccounts = await _accountService.countUser();
            LastSevenDays = Enumerable.Range(0, 7)
                            .Select(i => DateTime.Today.AddDays(-i).ToString("MM/dd"))
                            .Reverse().ToList();
            BookingsPerDay = await _bookingServices.BookingPerDays();
            while (BookingsPerDay.Count < 7)
            {
                BookingsPerDay.Insert(0, 0);
            }
            return Page();
        }
        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}

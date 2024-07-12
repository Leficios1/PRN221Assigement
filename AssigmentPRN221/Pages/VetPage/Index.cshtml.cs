    using System;
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

namespace AssigmentPRN221.Pages.VetPage
{
    public class IndexModel : PageModel
    {
        private readonly IBookingServices _bookingServices;
        private readonly IAccountService _accountService;

        public IndexModel(IBookingServices bookingServices, IAccountService accountService)
        {
            _bookingServices = bookingServices;
            _accountService = accountService;
        }

        public List<BookingResponseDTO> Bookings { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var email = HttpContext.Session.GetString("UserEmail");
            if (email == null)
            {
                return RedirectToPage("/LoginPage");
            }
            var vetId = await _accountService.GetAccountInfoByEmail(email);
            Bookings = await _bookingServices.getAllBookingByVetId(vetId.Id);
            return Page();
        }
    }
}

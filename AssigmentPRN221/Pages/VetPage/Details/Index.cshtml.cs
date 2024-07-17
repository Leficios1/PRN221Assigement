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
using Services.Services;

namespace AssigmentPRN221.Pages.VetPage.Details
{
    public class IndexModel : PageModel
    {
        private readonly IBookingServices _bookingServices;

        public IndexModel(IBookingServices bookingServices)
        {
            _bookingServices = bookingServices;
        }

        public BookingResponseDTO BookingResponseDTO { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var booking = await _bookingServices.getBookingDetailsByBookingId(id);
            if (booking == null)
            {
                return NotFound();
            }
            BookingResponseDTO = booking;
            return Page();
        }
        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
        public async Task<IActionResult> OnPostCheckoutAsync(int id)
        {
            var result = await _bookingServices.updateStatus(id);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Change status failed.");
                return Page();
            }

            return RedirectToPage("/VetPage/Index");
        }
    }
}

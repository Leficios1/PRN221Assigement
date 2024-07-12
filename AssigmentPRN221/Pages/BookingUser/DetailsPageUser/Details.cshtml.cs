using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Model.Entities;
using DataAccessObject.Database;

namespace AssigmentPRN221.Pages.BookingUser.DetailsPageUser
{
    public class DetailsModel : PageModel
    {
        private readonly DataAccessObject.Database.PetManagementContext _context;

        public DetailsModel(DataAccessObject.Database.PetManagementContext context)
        {
            _context = context;
        }

      public BookingDetails BookingDetails { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BookingDetails == null)
            {
                return NotFound();
            }

            var bookingdetails = await _context.BookingDetails.FirstOrDefaultAsync(m => m.Id == id);
            if (bookingdetails == null)
            {
                return NotFound();
            }
            else 
            {
                BookingDetails = bookingdetails;
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

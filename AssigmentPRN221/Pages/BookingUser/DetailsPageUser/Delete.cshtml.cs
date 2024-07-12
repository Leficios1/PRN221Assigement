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
    public class DeleteModel : PageModel
    {
        private readonly DataAccessObject.Database.PetManagementContext _context;

        public DeleteModel(DataAccessObject.Database.PetManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.BookingDetails == null)
            {
                return NotFound();
            }
            var bookingdetails = await _context.BookingDetails.FindAsync(id);

            if (bookingdetails != null)
            {
                BookingDetails = bookingdetails;
                _context.BookingDetails.Remove(BookingDetails);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}

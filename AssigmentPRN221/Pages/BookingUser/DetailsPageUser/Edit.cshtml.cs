using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Model.Entities;
using DataAccessObject.Database;

namespace AssigmentPRN221.Pages.BookingPageUser.DetailsPageUser
{
    public class EditModel : PageModel
    {
        private readonly DataAccessObject.Database.PetManagementContext _context;

        public EditModel(DataAccessObject.Database.PetManagementContext context)
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

            var bookingdetails =  await _context.BookingDetails.FirstOrDefaultAsync(m => m.Id == id);
            if (bookingdetails == null)
            {
                return NotFound();
            }
            BookingDetails = bookingdetails;
           ViewData["PetId"] = new SelectList(_context.Pets, "Id", "PetName");
           ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingId");
           ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "ServiceName");
           ViewData["VetId"] = new SelectList(_context.Vets, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BookingDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingDetailsExists(BookingDetails.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookingDetailsExists(int id)
        {
          return (_context.BookingDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}

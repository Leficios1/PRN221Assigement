using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Model.Entities;
using DataAccessObject.Database;

namespace AssigmentPRN221.Pages.KennelPage
{
    public class DeleteModel : PageModel
    {
        private readonly DataAccessObject.Database.PetManagementContext _context;

        public DeleteModel(DataAccessObject.Database.PetManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Kennel Kennel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Kennels == null)
            {
                return NotFound();
            }

            var kennel = await _context.Kennels.FirstOrDefaultAsync(m => m.KennelId == id);

            if (kennel == null)
            {
                return NotFound();
            }
            else 
            {
                Kennel = kennel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Kennels == null)
            {
                return NotFound();
            }
            var kennel = await _context.Kennels.FindAsync(id);

            if (kennel != null)
            {
                Kennel = kennel;
                _context.Kennels.Remove(Kennel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

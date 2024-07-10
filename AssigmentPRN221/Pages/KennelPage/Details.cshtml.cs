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
    public class DetailsModel : PageModel
    {
        private readonly DataAccessObject.Database.PetManagementContext _context;

        public DetailsModel(DataAccessObject.Database.PetManagementContext context)
        {
            _context = context;
        }

      public Kennel Kennel { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var email = HttpContext.Session.GetString("UserEmail");
            if (email == null)
            {
                return RedirectToPage("/LoginPage");
            }
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
        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}

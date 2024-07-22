using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BussinessObject.Model.Entities;
using DataAccessObject.Database;
using Services.Services.Interface;
using BussinessObject.Model.ENUM;

namespace AssigmentPRN221.Pages.PetsPage
{
    public class CreateModel : PageModel
    {
        private readonly DataAccessObject.Database.PetManagementContext _context;
        private readonly IAccountService _accountService;

        public CreateModel(DataAccessObject.Database.PetManagementContext context, IAccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }

        public IActionResult OnGet()
        {
        ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Pet Pet { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var email = HttpContext.Session.GetString("UserEmail");
            if (email == null)
            {
                return RedirectToPage("/LoginPage");
            }

            var userInfo = await _accountService.GetAccountInfoByEmail(email);
            Pet.UserId = userInfo.Id;
            Pet.Status = (int)StatusEnum.active;
            _context.Pets.Add(Pet);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}

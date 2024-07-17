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

namespace AssigmentPRN221.Pages.PetsPage
{
    public class IndexModel : PageModel
    {
        private readonly DataAccessObject.Database.PetManagementContext _context;
        private readonly IPetServices _petServices;
        private readonly IAccountService _accountService;

        public IndexModel(DataAccessObject.Database.PetManagementContext context,
            IPetServices petServices,
            IAccountService accountService)
        {
            _context = context;
            _petServices = petServices;
            _accountService = accountService;
        }

        public List<PetResponseDTO> Pet { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var email = HttpContext.Session.GetString("UserEmail");
            if (email == null)
            {
                return RedirectToPage("/LoginPage");
            }
            var userInfo = await _accountService.GetAccountInfoByEmail(email);
            if (_context.Pets != null)
            {
                Pet = await _petServices.getPetByUserId(userInfo.Id);
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

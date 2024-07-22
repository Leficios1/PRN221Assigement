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
    public class DetailsModel : PageModel
    {
        private readonly DataAccessObject.Database.PetManagementContext _context;
        private readonly IPetServices _petServices;

        public DetailsModel(DataAccessObject.Database.PetManagementContext context, IPetServices petServices)
        {
            _context = context;
            _petServices = petServices;
        }

      public PetResponseDTO Pet { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int id)
        {

            var pet = await _petServices.getById(id);
            if (pet == null)
            {
                return NotFound();
            }
            else 
            {
                Pet = pet;
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

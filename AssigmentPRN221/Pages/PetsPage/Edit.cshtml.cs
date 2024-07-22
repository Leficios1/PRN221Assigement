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
using Services.Services.Interface;
using BussinessObject.DTOs.Response;
using BussinessObject.DTOs.Request;

namespace AssigmentPRN221.Pages.PetsPage
{
    public class EditModel : PageModel
    {
        private readonly IPetServices _petservices;
        private readonly IAccountService _accountServices;

        public EditModel(IPetServices petServices, IAccountService accountService)
        {
            _petservices = petServices;
            _accountServices = accountService;
        }

        [BindProperty]
        public PetRequestDTO Pet { get; set; } = default!;
        public PetResponseDTO PetResponse { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var email = HttpContext.Session.GetString("UserEmail");
            if (email == null)
            {
                return RedirectToPage("/LoginPage");
            }
            PetResponse = await _petservices.getById(id);
            if (PetResponse == null)
            {
                return NotFound();
            }
            Pet = new PetRequestDTO
            {
                Id = PetResponse.Id,
                PetName = PetResponse.PetName,
                PetType = PetResponse.PetType,
                BirthDate = PetResponse.BirthDate,
                PetGender = PetResponse.PetGender,
                PetSecialFeatures = PetResponse.PetSecialFeatures
            };
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Address");
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _petservices.updatePets(Pet);
            return RedirectToPage("./Index");
        }
        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}

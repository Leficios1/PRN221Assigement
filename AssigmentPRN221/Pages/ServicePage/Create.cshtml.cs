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
using BussinessObject.DTOs.Request;

namespace AssigmentPRN221.Pages.ServicePage
{
    public class CreateModel : PageModel
    {
        private readonly IServiceServices _serviceServices;

        public CreateModel(IServiceServices serviceServices)
        {
            _serviceServices = serviceServices;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ServiceRequestDTO Service { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var email = HttpContext.Session.GetString("UserEmail");
            if (email == null)
            {
                return RedirectToPage("/LoginPage");
            }

            await _serviceServices.AddService(Service);
            return RedirectToPage("./Index");
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}

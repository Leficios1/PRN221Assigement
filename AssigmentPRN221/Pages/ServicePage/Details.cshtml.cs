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

namespace AssigmentPRN221.Pages.ServicePage
{
    public class DetailsModel : PageModel
    {
        private readonly IServiceServices _serviceServices;

        public DetailsModel(IServiceServices serviceServices)
        {
            _serviceServices = serviceServices;
        }

      public ServiceResponseDTO Service { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var email = HttpContext.Session.GetString("UserEmail");
            if (email == null)
            {
                return RedirectToPage("/LoginPage");
            }

            var service = await _serviceServices.GetServiceById(id);
            if (service == null)
            {
                return NotFound();
            }
            else 
            {
                Service = service;
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

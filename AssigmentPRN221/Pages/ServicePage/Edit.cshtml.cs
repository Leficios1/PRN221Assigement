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

namespace AssigmentPRN221.Pages.ServicePage
{
    public class EditModel : PageModel
    {
        private readonly IServiceServices _serviceServices;

        public EditModel(IServiceServices serviceServices)
        {
           _serviceServices = serviceServices;
        }

        [BindProperty]
        public ServiceResponseDTO Service { get; set; } = default!;
        public ServiceRequestDTO ServicesUpdate { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {

            var service = await _serviceServices.GetServiceById(id);
            if (service == null)
            {
                return NotFound();
            }
            Service = service;
            ServicesUpdate = new ServiceRequestDTO
            {
                Id = service.Id,
                ServiceName = service.ServiceName,
                ServiceCharge = service.ServiceCharge,
            };
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
            try
            {
                var data = await _serviceServices.UpdateService(ServicesUpdate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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

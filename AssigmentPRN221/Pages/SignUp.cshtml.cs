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

namespace AssigmentPRN221.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly IUserServices _userServices;

        public SignUpModel(IUserServices userServices)
        {
            _userServices = userServices;
        }


        [BindProperty]
        public UserRequestDTO User { get; set; } = default!;
        

        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            await _userServices.createUser(User);
            return RedirectToPage("./LoginPage");
        }
    }
}

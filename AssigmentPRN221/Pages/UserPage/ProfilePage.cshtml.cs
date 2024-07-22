using BussinessObject.DTOs.Response;
using BussinessObject.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Services.Interface;

namespace AssigmentPRN221.Pages.UserPage
{
    public class ProfilePageModel : PageModel
    {
        private readonly IAccountService _accServices;

        public ProfilePageModel(IAccountService accServices)
        {
            _accServices = accServices;
        }

        public User UserResponseDTO { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            var email = HttpContext.Session.GetString("UserEmail");
            if (email == null)
            {
                return RedirectToPage("/LoginPage");
            }
            UserResponseDTO = await _accServices.GetAccountInfoByEmail(email);

            return Page();
        }

        public IActionResult OnPostLogout()
        {
            // Clear the session
            HttpContext.Session.Clear();

            // Redirect to Index page
            return RedirectToPage("/Index");
        }
    }
}

using BussinessObject.DTOs.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Services.Interface;

namespace AssigmentPRN221.Pages
{
    public class UserModel : PageModel
    {
        private readonly IUserServices _userServices;

        public UserModel(IUserServices userServices)
        {
            _userServices = userServices;
        }

        public List<UserResponseDTO> Users { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var email = HttpContext.Session.GetString("UserEmail");
            if (email == null)
            {
                return RedirectToPage("/LoginPage");
            }
            Users = await _userServices.getAllUserAsync();
            return Page();
        }
        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}

using BussinessObject.DTOs.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Services.Interface;

namespace AssigmentPRN221.Pages
{
    public class LoginPageModel : PageModel
    {
        private readonly ILogger<LoginPageModel> _logger;
        private readonly IAccountService _accountServices;

        public LoginPageModel(ILogger<LoginPageModel> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountServices = accountService;
        }
        [BindProperty]
        public LoginRequestDTO Input { get; set; }
        public string ReturnURL { get; set; }
        public void OnGet(string returnURL = null)
        {
            ReturnURL = returnURL;
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var check = await _accountServices.Login(Input.Email, Input.Password);
            if (check == 1)
            {
                HttpContext.Session.SetString("UserEmail", Input.Email);
                HttpContext.Session.SetInt32("Roles", check);
                return RedirectToPage("./Welcome");
            }else if (check == 2)
            {
                HttpContext.Session.SetString("UserEmail", Input.Email);
                HttpContext.Session.SetInt32("Roles", check);
                return RedirectToPage("/KennelPage/KennelWelcom");
            }
            else if (check == 3)
            {
                HttpContext.Session.SetString("UserEmail", Input.Email);
                HttpContext.Session.SetInt32("Roles", check);
                return RedirectToPage("/UserPage/Index");
            }
            else if (check == 4)
            {
                HttpContext.Session.SetString("UserEmail", Input.Email);
                HttpContext.Session.SetInt32("Roles", check);
                return RedirectToPage("/Vet/Index");
            }
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }
    }
}

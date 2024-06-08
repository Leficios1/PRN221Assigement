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

        public async Task OnGet()
        {
            Users = await _userServices.getAllUserAsync();
        }
    }
}

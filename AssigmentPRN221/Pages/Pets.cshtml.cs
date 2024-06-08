using BussinessObject.DTOs.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Services.Interface;

namespace AssigmentPRN221.Pages
{
    public class PetsModel : PageModel
    {

        private readonly IPetServices _petServices;

        public PetsModel(IPetServices petServices)
        {
            _petServices = petServices;
        }

        public List<PetResponseDTO> Pets { get; set; }

        public async Task OnGet()
        {
            Pets = await _petServices.getAllPetsAsync();
        }
    }
}

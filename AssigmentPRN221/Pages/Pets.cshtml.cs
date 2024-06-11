using AutoMapper;
using BussinessObject.DTOs.Request;
using BussinessObject.DTOs.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Services.Services;
using Services.Services.Interface;

namespace AssigmentPRN221.Pages
{
    public class PetsModel : PageModel
    {

        private readonly IPetServices _petServices;
        private readonly IPetRecordServices _petRecordServices;
        private readonly IMapper _mapper;

        public PetsModel(IPetServices petServices, IPetRecordServices petRecordServices, IMapper mapper)
        {
            _petServices = petServices;
            _petRecordServices = petRecordServices;
            _mapper = mapper;
        }

        public List<PetRecordResponseDTO> Pets { get; set; }
        public string PetDataJson { get; set; }

        public async Task OnGet()
        {
            Pets = await _petServices.getAllPetsAsync();
            PetDataJson = JsonConvert.SerializeObject(Pets);

        }

        public async Task<IActionResult> OnPostUpdateAsync(PetRequestDTO pet)
        {
            await _petServices.updatePets(pet);
            await _petServices.getAllPetsAsync();
            return new JsonResult(new { success = true });
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _petServices.deletePet(id);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnGetPetRecord(int id)
        {
            try
            {
                var petDetails = await _petRecordServices.GetPetRecordByPetOrVetID(id);
                if (petDetails == null)
                {
                    return NotFound();
                }
                return new JsonResult(petDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }
    }
}

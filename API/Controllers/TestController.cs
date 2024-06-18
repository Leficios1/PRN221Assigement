using BussinessObject.DTOs.Request;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Interface;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IPetRecordServices _petRecordservices;
        private readonly IKennelService _kennelService;
        private readonly IPetServices _petServices;

        public TestController(IPetRecordServices petRecordservices, IPetServices petServices, IKennelService kennelService )
        {
            _petRecordservices = petRecordservices;
            _petServices = petServices;
            _kennelService = kennelService;
        }

        [HttpGet("getPetRecordById/{id}")]
        public async Task<IActionResult> getPetRecordById([FromRoute] int id)
        {
            var response = await _petRecordservices.GetPetRecordByPetOrVetID(id);
            return Ok(response);
        }
        [HttpGet("getAllKennel")]
        public async Task<IActionResult> GetAllKennel()
        {
            var response = await _kennelService.GetAllKennel();
            return Ok(response);
        }

        [HttpPut("updatePet")]
        public async Task<IActionResult> updatePet([FromBody] PetRequestDTO dto)
        {
            var response = await _petServices.updatePets(dto);
            return Ok(response);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Services.Services.Interface;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IPetRecordServices _petRecordservices;

        public TestController(IPetRecordServices petRecordservices)
        {
            _petRecordservices = petRecordservices;
        }

        [HttpGet("getPetRecordById/{id}")]
        public async Task<IActionResult> getPetRecordById([FromRoute] int id)
        {
            var response = await _petRecordservices.GetPetRecordByPetOrVetID(id);
            return Ok(response);
        }
    }
}

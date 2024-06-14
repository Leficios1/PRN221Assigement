using BussinessObject.DTOs.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Services.Interface;

namespace AssigmentPRN221.Pages
{
    public class KennelModel : PageModel
    {
        private readonly IKennelService _kennelService;
        public List<KennelResponseDTO> listKennel { get; set; }
        public KennelModel(IKennelService kennelService)
        {
            _kennelService = kennelService;
        }

        public async Task OnGet()
        {
            listKennel = await _kennelService.GetAllKennel();
        }
    }
}

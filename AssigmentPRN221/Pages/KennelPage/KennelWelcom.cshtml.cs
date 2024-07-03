using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Model.Entities;
using DataAccessObject.Database;
using Services.Services.Interface;
using BussinessObject.DTOs.Response;

namespace AssigmentPRN221.Pages.KennelPage
{
    public class KennelWelcom : PageModel
    {
        private readonly IKennelService _kennelService;

        public KennelWelcom(IKennelService kennelService)
        {
            _kennelService = kennelService;
        }

        public IList<KennelResponseDTO> Kennel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Kennel =  await _kennelService.GetAllKennel();
        }
    }
}

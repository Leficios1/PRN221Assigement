using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Model.Entities;
using DataAccessObject.Database;
using AutoMapper;
using Services.Services.Interface;
using BussinessObject.DTOs.Request;

namespace AssigmentPRN221.Pages.KennelPage
{
    public class DeleteModel : PageModel
    {
        private readonly IKennelService _kennelService;
        private readonly IMapper _mapper;


        public DeleteModel(IKennelService kennelService, IMapper mapper)
        {
            _kennelService = kennelService;
            _mapper = mapper;
        }

        [BindProperty]
      public Kennel Kennel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kennel = await _kennelService.GetKennelById(id);

            if (kennel == null)
            {
                return NotFound();
            }
            else 
            {
                Kennel = kennel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var kennel = await _kennelService.GetKennelById(id);

            if (kennel != null)
            {
                Kennel = kennel;
                await _kennelService.DeleteKennel(id);
            }

            return RedirectToPage("./KennelWelcom");
        }
    }
}

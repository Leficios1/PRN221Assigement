using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BussinessObject.Model.Entities;
using DataAccessObject.Database;
using Services.Services.Interface;
using AutoMapper;
using BussinessObject.DTOs.Request;

namespace AssigmentPRN221.Pages.KennelPage
{
    public class CreateModel : PageModel
    {
        private readonly IKennelService _kennelService;
        private readonly IMapper _mapper;


        public CreateModel(IKennelService kennelService, IMapper mapper)
        {
            _kennelService = kennelService;
            _mapper = mapper;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Kennel Kennel { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (Kennel == null)
            {
                return Page();
            }
            var result = _mapper.Map<KennelRequestDTO>(Kennel);
            var message = await _kennelService.AddKennen(result);
            if (message.Equals("Dupplicate RoomNumber!"))
            {
                ViewData["Message"] = message;
                return Page();
            }
            else
            {
                return RedirectToPage("./KennelWelcom");
            }     
            
        }
    }
}

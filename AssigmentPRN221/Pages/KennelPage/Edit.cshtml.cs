using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Model.Entities;
using DataAccessObject.Database;
using AutoMapper;
using Services.Services.Interface;
using BussinessObject.DTOs.Request;
using BussinessObject.DTOs.Response;

namespace AssigmentPRN221.Pages.KennelPage
{
    public class EditModel : PageModel
    {
        private readonly IKennelService _kennelService;
        private readonly IMapper _mapper;

        public EditModel(IKennelService kennelService, IMapper mapper)
        {
            _kennelService = kennelService;
            _mapper = mapper;
        }

        [BindProperty]
        public Kennel Kennel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var email = HttpContext.Session.GetString("UserEmail");
            if (email == null)
            {
                return RedirectToPage("/LoginPage");
            }
            if (id == null)
            {
                return NotFound();
            }

            var kennel =  await _kennelService.GetKennelById(id);
            if (kennel == null)
            {
                return NotFound();
            }
            Kennel = kennel;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                KennelRequestDTO kennelRequestDTO = new KennelRequestDTO();
                kennelRequestDTO.Id = Kennel.KennelId;
                kennelRequestDTO.Name = Kennel.Name;
                kennelRequestDTO.RoomNumber = Kennel.RoomNumber;
                kennelRequestDTO.Capacity = Kennel.Capacity;
                kennelRequestDTO.status = Kennel.status;

                var message = await _kennelService.UpdateKennel(kennelRequestDTO);
                if(message.Equals("Update successful!"))
                {
                    return RedirectToPage("./Details", new { id = kennelRequestDTO.Id });
                }
                else
                {
                    ViewData["Message"] = message;
                    return Page();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KennelExists(Kennel.KennelId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool KennelExists(int id)
        {
            var kennel = _kennelService.GetKennelById(id);
            if(kennel == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}

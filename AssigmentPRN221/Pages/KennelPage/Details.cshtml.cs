using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Model.Entities;
using DataAccessObject.Database;
using Services.Services;
using BussinessObject.DTOs.Response;
using Services.Services.Interface;

namespace AssigmentPRN221.Pages.KennelPage
{
    public class DetailsModel : PageModel
    {
        private readonly IKennelService _kennelService;
        private readonly IKennelRecordService _kennelRecordService;

        public DetailsModel(IKennelService kennelService, IKennelRecordService kennelRecordService)
        {
            _kennelService = kennelService;
            _kennelRecordService = kennelRecordService;
        }

        public Kennel Kennel { get; set; } = default!; 
      public KennelRecordResponseDTO KennelRecord { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var email = HttpContext.Session.GetString("UserEmail");
            if (email == null)
            {
                return RedirectToPage("/LoginPage");
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
            var kennelRecordData = await _kennelRecordService.getByKennelStatus(kennel.KennelId);
            if (kennelRecordData == null)
            {
                return Page();
            }
            KennelRecord = kennelRecordData;
            return Page();
        }
        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPostCheckoutAsync(int id)
        {
            var result = await _kennelRecordService.checkoutKennel(id);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Checkout failed.");
                return Page();
            }

            return RedirectToPage("./KennelWelcom");
        }
    }
}

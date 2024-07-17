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
    public class KennelRecordIndexModel : PageModel
    {
        private readonly IKennelRecordService _kennelRecordService;

        public KennelRecordIndexModel(IKennelRecordService kennelRecordService)
        {
            _kennelRecordService = kennelRecordService;
        }

        public List<KennelRecordResponseDTO> KennelRecord { get;set; } = default!;

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
            var data = await _kennelRecordService.getByKennlId(id);
            if (data == null)
            {
                return NotFound();
            }
            KennelRecord = data;
            return Page();

        }
        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}

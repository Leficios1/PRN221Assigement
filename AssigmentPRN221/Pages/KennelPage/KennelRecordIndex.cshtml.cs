using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Model.Entities;
using DataAccessObject.Database;

namespace AssigmentPRN221.Pages.KennelPage
{
    public class KennelRecordIndexModel : PageModel
    {
        private readonly DataAccessObject.Database.PetManagementContext _context;

        public KennelRecordIndexModel(DataAccessObject.Database.PetManagementContext context)
        {
            _context = context;
        }

        public IList<KennelRecord> KennelRecord { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.KennelRecords != null)
            {
                KennelRecord = await _context.KennelRecords
                .Include(k => k.Kennel)
                .Include(k => k.Pet).ToListAsync();
            }
        }
    }
}

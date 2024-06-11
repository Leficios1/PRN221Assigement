using BussinessObject.Model.Entities;
using DataAccessObject.Database;
using DataAccessObject.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Repository
{
    public class PetRecordRepository: BaseRepository<PetRecord>, IPetRecordRepository
    {
        private readonly PetManagementContext _context;

        public PetRecordRepository(PetManagementContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<PetRecord>> getByPetId(int petid)
        {
            var data = await _context.PetRecords.Where(x => x.PetId == petid).ToListAsync();
            return data;
        }
    }
}

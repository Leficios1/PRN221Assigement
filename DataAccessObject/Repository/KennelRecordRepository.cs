using BussinessObject.DTOs.Response;
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
    public class KennelRecordRepository : IKennelRecordRepository
    {
        private readonly PetManagementContext _context;

        public KennelRecordRepository(PetManagementContext context)
        {
            _context = context;
        }
        public async Task<List<KennelRecord>> GetAll()
        {
            return await _context.KennelRecords.ToListAsync();
        }

        public async Task AddkennelRecord(KennelRecord record)
        {
            await _context.KennelRecords.AddAsync(record);
            _context.SaveChanges();
        }

        public async Task<KennelRecord> GetById(int id)
        {
            return await _context.KennelRecords.FindAsync(id);
        }

        public async Task UpdateKennelRecord(KennelRecord entity)
        {
            _context.KennelRecords.Update(entity);
            _context.SaveChanges();
        }
    }
}

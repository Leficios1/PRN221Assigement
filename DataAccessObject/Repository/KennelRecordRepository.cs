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

        public Task<List<KennelRecord>> getByPetId(int petid)
        {
            var data = _context.KennelRecords.Include(p => p.Pet).Include(p => p.Kennel)
                        .Where(p => p.PetId == petid).OrderByDescending(kr => kr.Id).ToListAsync();
            return data;
        }

        public KennelRecord getByPetIddto(int petid)
        {
            var data =  _context.KennelRecords.FirstOrDefault(kr => kr.status == true && kr.PetId == petid);
            return data;
        }

        public Task<List<KennelRecord>> getByKennelId(int kennelId)
        {
            var data = _context.KennelRecords.Include(p => p.Pet).Include(p => p.Kennel)
            .Where(p => p.KennelId == kennelId).ToListAsync();
            return data;
        }

        public async Task<KennelRecord> getKennelActive(int kennelId)
        {
            var data = await _context.KennelRecords.Include(p => p.Pet).Include(p => p.Kennel)
                    .Where(p => p.KennelId == kennelId && p.status == true).SingleOrDefaultAsync();
            return data;
        }

        public async Task<string?> getKennelNameActiveByPetId(int petid)
        {
            var data = await _context.KennelRecords.Include(p => p.Pet).Include(p => p.Kennel)
                    .Where(p => p.PetId == petid && p.status == true).SingleOrDefaultAsync();
            if (data == null)
            {
                return null;
            }
            return data.Kennel.Name;
        }

        public async Task<bool> checkoutKennel(int KennelId)
        {
            var data = await _context.KennelRecords.Include(p => p.Pet).Include(p => p.Kennel)
                    .Where(p => p.KennelId == KennelId && p.status == true).SingleOrDefaultAsync();
            if (data == null)
            {
                return false;
            }
            data.CheckOutDate = DateTime.UtcNow;
            data.status = false;
            data.Kennel.status = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

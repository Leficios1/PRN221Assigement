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
    public class KennelRepository : BaseRepository<Kennel>, IKennelRepository
    {
        private readonly PetManagementContext _context;
        public KennelRepository(PetManagementContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Kennel>> GetAll()
        {
            return await _context.Kennels.ToListAsync();
            
        }
        public async Task AddKennel(Kennel kennel)
        { 
            await _context.Kennels.AddAsync(kennel);
            _context.SaveChanges();
        }

        public async Task<List<Kennel>> GetAllInvalidKennel()
        {
            return await _context.Kennels.Where(k => k.status == true).ToListAsync();
        }

        public async Task UpdateKennel(Kennel kennel)
        {
            _context.Kennels.Update(kennel);
            _context.SaveChanges();
        }
        public async Task<Kennel> GetById(int id)
        {
            return await _context.Kennels.FindAsync(id);
        }

        public async Task DeleteKennel(Kennel kennel)
        {
            _context.Kennels.Remove(kennel);
            _context.SaveChanges();
        }
    }
}

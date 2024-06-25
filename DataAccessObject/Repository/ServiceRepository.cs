using BussinessObject.DTOs.Request;
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
    public class ServiceRepository : IServiceRepository
    {
        private readonly PetManagementContext _context;
        public ServiceRepository(PetManagementContext dbcontext)
        {
            _context = dbcontext;
        }

        public async Task AddService(Service entity)
        {
            await _context.Services.AddAsync(entity);
            _context.SaveChanges();
        }

        public async Task DeleteService(Service entity)
        {
            _context.Services.Update(entity);
            await _context.SaveChangesAsync();
           
        }

        public async Task<List<Service>> GetAll()
        {
            return await _context.Services.ToListAsync();

        }

        public async Task<List<Service>> GetAllValid()
        {
            return await _context.Services.Where(s => s.status == true).ToListAsync();
        }

        public async Task<Service> GetById(int id)
        {
            return await _context.Services.Where(s => s.Id == id).SingleOrDefaultAsync();
        }

        public async Task Update(Service entity)
        {
            _context.Services.Update(entity);
            await _context.SaveChangesAsync();
            
        }
    }
}

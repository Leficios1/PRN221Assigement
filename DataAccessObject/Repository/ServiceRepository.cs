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
    public class ServiceRepository : BaseRepository<Service>,IServiceRepository
    {
        public ServiceRepository(PetManagementContext dbcontext) : base(dbcontext)
        {
        }

        public async Task<string> DeleteService(int id)
        {
            var result = await this.GetById(id);
            this.Delete(result);
            await this.SaveChangesAsync();
            return "Delete Successful!";
        }

        public async Task<List<Service>> GetAll()
        { 
            return await _

        }

        public async Task<List<Service>> GetAllValid()
        {
            return await _dbcontext.Services.Where(s => s.status == true).ToListAsync();
        }

        public async Task<Service> GetById(int id)
        {
            return await _dbcontext.Services.FindAsync(id);
        }

        public Task<Service> Update(Service entity)
        {
            throw new NotImplementedException();
        }
    }
}

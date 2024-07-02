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
    public class ServicesRepository : BaseRepository<Service>, IServicesRepository
    {
        private readonly PetManagementContext _context;

        public ServicesRepository(PetManagementContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Service>> getAll()
        {
            var data = await _context.Services.ToListAsync();
            return data;
        }
    }
}

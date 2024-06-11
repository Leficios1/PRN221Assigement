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
    public class VetRepository : BaseRepository<Vet>, IVetRepository
    {
        private readonly PetManagementContext _context;

        public VetRepository(PetManagementContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Vet>> GetAllAsync()
        {
            var data = await _context.Vets.ToListAsync();
            return data;
        }
    }
}

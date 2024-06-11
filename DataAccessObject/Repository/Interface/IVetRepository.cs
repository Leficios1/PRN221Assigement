using BussinessObject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Repository.Interface
{
    public interface IVetRepository : IBaseRepository<Vet>
    {
        public Task<List<Vet>> GetAllAsync();
    }
}

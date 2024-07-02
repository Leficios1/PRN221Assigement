using BussinessObject.Model.Entities;
using DataAccessObject.Repository.Interface;
using Services.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class VetServices : IVetServices
    {
        private readonly IVetRepository _Vetrepository;

        public VetServices(IVetRepository vetrepository)
        {
            _Vetrepository = vetrepository;
        }

        public async Task<List<Vet>> getAll()
        {
            return await _Vetrepository.GetAllAsync();
        }
    }
}

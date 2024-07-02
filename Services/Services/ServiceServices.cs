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
    public class ServiceServices : IServiceServices
    {
        private readonly IServicesRepository _servicesRepository;

        public ServiceServices(IServicesRepository servicesRepository)
        {
            _servicesRepository = servicesRepository;
        }

        public async Task<List<Service>> getAll()
        {
            return await _servicesRepository.getAll();
        }
    }
}

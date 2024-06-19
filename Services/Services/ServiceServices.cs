using AutoMapper;
using BussinessObject.DTOs.Request;
using BussinessObject.DTOs.Response;
using DataAccessObject.Repository.Interface;
using Services.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ServiceServices : IServiceSevices
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;


        public ServiceServices(IServiceRepository serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }
        public Task<string> DeleteService(int id)
        {
            
        }

        public async Task<List<ServiceResponseDTO>> GetAllService()
        {
            var service = await _serviceRepository.GetAll();
            var response = _mapper.Map<List<ServiceRequestDTO>>(service);
            return response;
        }

        public Task<List<ServiceResponseDTO>> GetAllValidService()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponseDTO> GetServiceById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponseDTO> UpdateService(ServiceRequestDTO dto)
        {
            throw new NotImplementedException();
        }

        }
    }
}

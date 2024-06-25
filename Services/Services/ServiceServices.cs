using AutoMapper;
using BussinessObject.DTOs.Request;
using BussinessObject.DTOs.Response;
using DataAccessObject.Repository.Interface;
using Microsoft.IdentityModel.Tokens;
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

        public async Task<string> AddService(ServiceRequestDTO dto)
        {
            try
            {
                if(dto.ServiceName.IsNullOrEmpty())
                {
                    return "Name can't null!";
                }
                if(dto.ServiceCharge < 0)
                {
                    return "service Charge can't < 0!";
                }
                var service = new BussinessObject.Model.Entities.Service()
                {
                    ServiceName = dto.ServiceName,
                    ServiceCharge = dto.ServiceCharge,
                    status = true,
                };
                await _serviceRepository.AddService(service);
                return "Add Service successful!";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> DeleteService(int id)
        {
            try
            {
                var service =  await _serviceRepository.GetById(id);
                if (service == null)
                {
                    return null;
                }
                else
                {
                    await _serviceRepository.DeleteService(service);
                    return "Delete successful!";
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<List<ServiceResponseDTO>> GetAllService()
        {
            try
            {
                var service = await _serviceRepository.GetAll();
                var response = _mapper.Map<List<ServiceResponseDTO>>(service);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }

        }

        public async Task<List<ServiceResponseDTO>> GetAllValidService()
        {
            try
            {
                var service = await _serviceRepository.GetAllValid();
                var response = _mapper.Map<List<ServiceResponseDTO>>(service);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ServiceResponseDTO> GetServiceById(int id)
        {
            try
            {
                var service = await _serviceRepository.GetById(id);
                if (service == null)
                {
                    return null;
                }
                else
                {
                    var response = _mapper.Map<ServiceResponseDTO>(service);
                    return response;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }         
        }

        public async Task<string> UpdateService(ServiceRequestDTO dto)
        {
            try
            {
                var service = await _serviceRepository.GetById(dto.Id);
                if(service == null)
                {
                    return null;
                }
                else
                {
                    if(dto.ServiceName.IsNullOrEmpty())
                    {
                        service.ServiceName = dto.ServiceName;
                    }
                    if(dto.ServiceCharge >= 0)
                    {
                        service.ServiceCharge = dto.ServiceCharge;
                    }
                    await _serviceRepository.Update(service);
                    return "Update Successful!";
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

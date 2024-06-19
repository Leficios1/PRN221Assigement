using BussinessObject.DTOs.Request;
using BussinessObject.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interface
{
    public interface IServiceSevices
    {
        Task<List<ServiceResponseDTO>> GetAllService();
        Task<List<ServiceResponseDTO>> GetAllValidService();
        Task<ServiceResponseDTO> GetServiceById(int id);
        Task<ServiceResponseDTO> UpdateService(ServiceRequestDTO dto);
        Task<string> DeleteService(int id);
    }
}

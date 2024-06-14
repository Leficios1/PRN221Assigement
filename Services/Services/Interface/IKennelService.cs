using BussinessObject.DTOs.Request;
using BussinessObject.DTOs.Response;
using BussinessObject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interface
{
    public interface IKennelService
    {
        Task<List<KennelResponseDTO>> GetAllKennel();
        Task<string> AddKennen(KennelRequestDTO dto);
        Task<List<KennelResponseDTO>> GetAllKennelInvalid();
        Task<string> UpdateKennel(KennelRequestDTO dto);
        Task<string> DeleteKennel(int id);
    }
}

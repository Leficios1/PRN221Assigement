using BussinessObject.DTOs.Request;
using BussinessObject.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interface
{
    public interface IKennelRecordService
    {
        Task<List<KennelRecordResponseDTO>> GetAll();
        Task<string> ReservationKennelRecord(KennelRecordRequestDTO dto);
        Task<string> AddKennelRecord(KennelRecordRequestDTO dto);
        Task<string> UpdateKennelRecord(KennelRecordRequestDTO dto);
        Task<List<KennelRecordResponseDTO>> getByPetId(int petId);
        Task<List<KennelRecordResponseDTO>> getByKennlId(int kennlId);
        Task<KennelRecordResponseDTO?> getByKennelStatus(int kennelId);
        Task<string?> GetKennelStatusByPetId(int petId);
        Task<bool> checkoutKennel(int kennelId);
    }
}

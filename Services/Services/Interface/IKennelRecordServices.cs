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
        Task<string> CheckInKennelRecord(KennelRecordRequestDTO dto);
        Task<string> UpdateKennelRecord(KennelRecordRequestDTO dto);
        Task<string> CheckOutKennelRecord(int id);
    }
}

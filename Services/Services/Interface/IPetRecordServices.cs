using BussinessObject.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interface
{
    public interface IPetRecordServices
    {
        Task<PetRecordResponseDTO> GetPetRecordByPetOrVetID(int petid);
    }
}

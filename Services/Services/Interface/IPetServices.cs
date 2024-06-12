using BussinessObject.DTOs.Request;
using BussinessObject.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interface
{
    public interface IPetServices
    {
        Task<PetResponseDTO> getPetByUserId(int userId);
        Task<List<PetRecordResponseDTO>> getAllPetsAsync();
        Task<PetResponseDTO> updatePets(PetRequestDTO dto);
        Task<PetResponseDTO> createPet(PetRequestDTO dto);
        Task<bool> deletePet(int id);
    }
}

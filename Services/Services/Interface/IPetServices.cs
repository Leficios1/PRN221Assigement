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
        Task<List<PetResponseDTO>> getPetByUserId(int userId);
        Task<List<PetRecordResponseDTO>> getAllPetsAsync();
        Task<PetResponseDTO> updatePets(PetRequestDTO dto);
        Task<PetResponseDTO> createPet(PetRequestDTO dto);
        Task<bool> deletePet(int id);
        Task<int> getPetIdByPetName(string name);
        Task<PetResponseDTO> getById(int id);
    }
}

using BussinessObject.DTOs.Request;
using BussinessObject.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interface
{
    public interface IUserServices
    {
        Task<List<UserResponseDTO>> getAllUserAsync();
        Task<UserResponseDTO> createUser(UserRequestDTO dto);
        Task<UserResponseDTO> updateUser(UserRequestDTO dto);
        Task<UserResponseDTO> deleteUser(int id);
    }
}

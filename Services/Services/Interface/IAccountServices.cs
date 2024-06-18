using BussinessObject.DTOs.Request;
using BussinessObject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interface
{
    public interface IAccountServices
    {
        Task<List<UserRequestDTO>> GetAllUserAscyn();
        Task<User> GetAccountInfoByEmail(string email);

        Task<UserRequestDTO> CreateAccount(UserRequestDTO account);

    }
}

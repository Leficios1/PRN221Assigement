using BussinessObject.DTOs.Request;
using BussinessObject.DTOs.Response;
using BussinessObject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Repository.Interface
{
    public interface IUserRepository : IBaseRepository<User>    
    {
        public Task<List<User>> getAllUserAsync();
        public Task<bool> createUser(User dto);
        public Task<bool> updateUser(User dto);
        public Task<bool> deleteUser(int id);
    }
}

using BussinessObject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Repository.Interface
{
    public interface IAccountRepository : IBaseRepository<User>
    {
        public Task<List<User>> GetAllAccount();

        public Task<User>GetAccountDetailByEmail(string email);
        public Task<User> GetAccountDetailById(int id);


        public Task<User> CreateAccountRepo(User user);
    }
}

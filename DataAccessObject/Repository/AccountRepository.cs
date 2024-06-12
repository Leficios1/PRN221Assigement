using BussinessObject.Model.Entities;
using DataAccessObject.Database;
using DataAccessObject.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Repository
{
    public class AccountRepository : BaseRepository<User>, IAccountRepository
    {
        private readonly PetManagementContext _context;

        public AccountRepository(PetManagementContext context):base(context) 
        {
            _context = context;
        }

        public async Task<User> CreateAccountRepo(User user)
        {
            _context.Add(user); 
            await _context.SaveChangesAsync();
            return user;
        }

        public Task<User> GetAccountDetailByEmail(string email)
        {
            var data = _context.Users.SingleOrDefaultAsync(u => u.Email == email);
            return data;
        }

        public Task<User> GetAccountDetailById(int id)
        {
            var data = _context.Users.SingleOrDefaultAsync(u => u.Id == id);
            return data;
        }

        public async Task<List<User>> GetAllAccount()
        {
            var data = await _context.Users.ToListAsync();  
            return data;
        }
    }
}

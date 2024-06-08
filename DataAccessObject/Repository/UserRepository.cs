using AutoMapper;
using BussinessObject.DTOs.Request;
using BussinessObject.DTOs.Response;
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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly PetManagementContext _context;
            
        public UserRepository(PetManagementContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> createUser(User dto)
        {
            try
            {
                var result = await _context.Users.AddAsync(dto);
                return true;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> deleteUser(int id)
        {
            var data = await _context.FindAsync<User>(id);
            if (data != null)
            {
                _context.Remove(data);
                return true;
            }else { return false; }
        }

        public async Task<List<User>> getAllUserAsync()
        {
            var data = await _context.Users.ToListAsync();
            return data;
        }

        public async Task<bool> updateUser(User dto)
        {
            var data = await _context.Users.Where(x => x.Id == dto.Id).SingleOrDefaultAsync();
            if(data != null)
            {
                _context.Users.Update(dto);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

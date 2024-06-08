using BussinessObject.Model.Entities;
using BussinessObject.Model.ENUM;
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
    public class PetRepository : BaseRepository<Pet>, IPetRepository
    {
        private readonly PetManagementContext _context;

        public PetRepository(PetManagementContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Pet> createPet(Pet entity)
        {
            var data = await _context.Pets.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> deletedPet(int id)
        {
            var data = await _context.Pets.FindAsync(id);
            if(data != null)
            {
                data.Status = (short)StatusEnum.inactive;
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                 return false;
            }
        }

        public async Task<List<Pet>> getAllPets()
        {
            var data = await _context.Pets.ToListAsync();
            return data;
        }

        public async Task<Pet> getPetByUserId(int userid)
        {
            var data = await _context.Pets.Where(x => x.UserId == userid).SingleOrDefaultAsync();
            return data;
        }

        public async Task<User> getUserNameByPetId(int id)
        {
            var data = await _context.Pets.Where(x => x.Id == id).SingleOrDefaultAsync();
            var user = await _context.Users.Where(u => u.Id == data.UserId).SingleOrDefaultAsync();
            return user;
        }

        public async Task<bool> UpdatePet(Pet dto)
        {
            var data = await _context.Pets.Where(x => x.Id == dto.Id).SingleOrDefaultAsync();
            if (data != null)
            {
                _context.Pets.Update(data);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}

using BussinessObject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Repository.Interface
{
    public interface IPetRepository : IBaseRepository<Pet>
    {
        public Task<Pet> getPetByUserId(int userid);
        public Task<List<Pet>> getAllPets();
        public Task<bool> UpdatePet(Pet dto);
        public Task<User> getUserNameByPetId(int id);
        public Task<Pet> createPet(Pet entity);
        public Task<bool> deletedPet(int id);
    }
}

using BussinessObject.DTOs.Response;
using BussinessObject.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Repository.Interface
{
    public interface IKennelRepository
    {
        Task<List<Kennel>> GetAll();
        Task<List<Kennel>> GetAllInvalidKennel();
        Task AddKennel(Kennel kennel);
        Task UpdateKennel(Kennel kennel);
        Task<Kennel> GetById(int id);
        Task DeleteKennel (Kennel kennel);
    }
}

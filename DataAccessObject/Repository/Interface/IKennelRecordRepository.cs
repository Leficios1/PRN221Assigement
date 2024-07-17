using BussinessObject.DTOs.Response;
using BussinessObject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Repository.Interface
{
    public interface IKennelRecordRepository
    {
        Task<List<KennelRecord>> GetAll();
        Task AddkennelRecord(KennelRecord entity);
        Task<KennelRecord> GetById(int id);
        Task UpdateKennelRecord(KennelRecord entity);
        Task<List<KennelRecord>> getByPetId(int petid);
        Task<List<KennelRecord>> getByKennelId(int kennelId);
        Task<KennelRecord> getKennelActive(int kennelId);
        Task<string?> getKennelNameActiveByPetId(int petid);
        Task<bool> checkoutKennel(int KennelId);
    }
}

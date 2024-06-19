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
    public interface IServiceRepository : IBaseRepository<Service>
    {
        Task<List<Service>> GetAll();
        //Task<Service> GetById(int id);
        Task<Service> Update(Service entity);
        Task<string> DeleteService(int id);
        Task<List<Service>> GetAllValid();

    }
}

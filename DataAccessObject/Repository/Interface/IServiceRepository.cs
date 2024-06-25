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
    public interface IServiceRepository
    {
        Task<List<Service>> GetAll();
        Task<Service> GetById(int id);
        Task Update(Service entity);
        Task AddService(Service entity);
        Task DeleteService(Service entity);
        Task<List<Service>> GetAllValid();

    }
}

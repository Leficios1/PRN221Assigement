using AutoMapper;
using BussinessObject.DTOs.Request;
using BussinessObject.DTOs.Response;
using BussinessObject.Model.Entities;
using DataAccessObject.Database;
using DataAccessObject.Repository.Interface;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Services.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class KennelService : IKennelService
    {
        private readonly IKennelRepository _kennelRepository;
        private readonly IMapper _mapper;


        public KennelService(IKennelRepository kennelRepository, IMapper mapper)
        {
            _mapper = mapper;
            _kennelRepository = kennelRepository;
        }

        public async Task<string> AddKennen(KennelRequestDTO dto)
        {
            try
            {
                var kennen = _mapper.Map<Kennel>(dto);
                kennen.status = true;
                await _kennelRepository.AddKennel(kennen);
                return "add successfull";
            }
            catch (Exception ex) 
            {
                throw new Exception("Error database!");
            }
        }

        public async Task<string> DeleteKennel(int id)
        {
            try
            {
                var kennel = await _kennelRepository.GetById(id);
                if (kennel != null)
                {
                    throw new Exception("Not found Kennel!");
                }
                else
                {
                    _kennelRepository.DeleteKennel(kennel);
                    return "remove kennel successful!";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error database!");
            }
        }

        public async Task<List<KennelResponseDTO>> GetAllKennel()
        {
            try
            {
                var kennel = await _kennelRepository.GetAll();  
                if (!kennel.IsNullOrEmpty()) 
                {
                    var data = _mapper.Map<List<KennelResponseDTO>>(kennel);
                    return data;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error database!");
            }


        }

        public async Task<List<KennelResponseDTO>> GetAllKennelInvalid()
        {
            try
            {
                var listKennel = await _kennelRepository.GetAllInvalidKennel();
                var listData = _mapper.Map<List<KennelResponseDTO>>(listKennel);
                if (listData.IsNullOrEmpty())
                {
                    return null;
                }
                return listData;
            }
            catch (Exception ex) 
            {
                throw new Exception("Error database!");
            }
        }

        public async Task<string> UpdateKennel(KennelRequestDTO dto)
        {
            try
            {
                var kennel = _kennelRepository.GetById(dto.Id);
                if(kennel != null)
                {
                    var data = await _mapper.Map(dto, kennel);
                    await _kennelRepository.UpdateKennel(data);
                    return "Update successful!";
                }
                else
                {
                    throw new Exception("not found kennel!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error database!");
            }
        }
    }
}

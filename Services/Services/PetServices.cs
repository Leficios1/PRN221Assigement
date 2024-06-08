using AutoMapper;
using BussinessObject.DTOs.Request;
using BussinessObject.DTOs.Response;
using BussinessObject.Model.Entities;
using BussinessObject.Model.ENUM;
using DataAccessObject.Repository.Interface;
using Services.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class PetServices : IPetServices
    {
        private readonly IPetRepository _petRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public PetServices(IPetRepository petRepository, IMapper mapper, IUserRepository userRepository)
        {
            _petRepository = petRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<PetResponseDTO> createPet(PetRequestDTO dto)
        {
            try
            {
                var data = await _petRepository.GetById(dto.Id);
                if (data == null)
                {
                    throw new Exception("Not Found Pet!!!");
                }
                var mapper = _mapper.Map<Pet>(dto);
                mapper.Status = (short)StatusEnum.active;
                var data1 = await _petRepository.createPet(mapper);
                var result = _mapper.Map<PetResponseDTO>(data1);
                return result;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> deletePet(int id)
        {
            try
            {
                var data = await _petRepository.GetById(id);
                if(data == null)
                {
                    throw new Exception("Not Found Pet!!!");
                }
                var flag  = await _petRepository.deletedPet(id);
                return flag;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<PetResponseDTO>> getAllPetsAsync()
        {
            try
            {
                var data = await _petRepository.getAllPets();
                if(data == null)
                {
                    throw new Exception("Error in database");
                }
                else
                {
                    var petsDTO= _mapper.Map<List<PetResponseDTO>>(data);
                    foreach(var petDTO in petsDTO)
                    {
                        var userName = await _petRepository.getUserNameByPetId(petDTO.Id);
                        if (userName != null)
                        {
                            petDTO.UserName = userName.Name;
                        }
                        else
                        {
                            petDTO.UserName = "Unknown";
                        }
                    }
                    return petsDTO;
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PetResponseDTO> getPetByUserId(int userId)
        {
            try
            {
                var data = await _petRepository.getPetByUserId(userId);
                if(data == null)
                {
                    throw new Exception("User hadn't pet yet");
                }
                else
                {
                    var result = _mapper.Map<PetResponseDTO>(data);
                    return result;
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PetResponseDTO> updatePets(PetRequestDTO dto)
        {
            try
            {
                var data = _mapper.Map<Pet>(dto);
                var flag = await _petRepository.UpdatePet(data);
                if (flag)
                {
                    var result = _mapper.Map<PetResponseDTO>(dto);
                    return result;
                }
                else
                {
                    throw new Exception("Not found Pet?");
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

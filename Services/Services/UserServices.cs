using AutoMapper;
using BussinessObject.DTOs.Request;
using BussinessObject.DTOs.Response;
using BussinessObject.Model.Entities;
using DataAccessObject.Repository.Interface;
using Services.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserServices(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserResponseDTO> createUser(UserRequestDTO dto)
        {
            try
            {
                var mapper = _mapper.Map<User>(dto);
                var data = await _userRepository.createUser(mapper);
                if (!data)
                {
                    throw new Exception("Lỗi khi tạo User");
                }
                else
                {
                    var result = _mapper.Map<UserResponseDTO>(data);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserResponseDTO> deleteUser(int id)
        {
            try
            {
                var flag = await _userRepository.deleteUser(id);
                if (flag)
                {
                    var data = await _userRepository.GetById(id);
                    var result = _mapper.Map<UserResponseDTO>(data);
                    return result;
                }
                else
                {
                    throw new Exception("Not Found User!!!");
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<UserResponseDTO>> getAllUserAsync()
        {
            try
            {
                var data = await _userRepository.getAllUserAsync();
                var mapper = _mapper.Map<List<UserResponseDTO>>(data);
                return mapper;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserResponseDTO> updateUser(UserRequestDTO dto)
        {
            try
            {
                var mapper = _mapper.Map<User>(dto);
                var flag = await _userRepository.updateUser(mapper);
                if (flag)
                {
                    var result = _mapper.Map<UserResponseDTO>(mapper);
                    return result;
                }
                else
                {
                    throw new Exception("Not Found User !!!");
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

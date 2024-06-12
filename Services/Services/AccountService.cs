using AutoMapper;
using BussinessObject.DTOs.Request;
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
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepo;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepo, IMapper mapper)
        {
            _accountRepo = accountRepo;
            _mapper = mapper;
        }

        public async Task<UserRequestDTO> CreateAccount(UserRequestDTO account)
        {
            try
            {
                var data = await _accountRepo.GetAllAccount();
                var checkExist = data.Where(x => x.Email.Equals(account.Email));

                if (checkExist.Any())
                {
                    return null;
                }

                var map = _mapper.Map<User>(account);
                var createAccount = await _accountRepo.CreateAccountRepo(map);
                var resutl = _mapper.Map<UserRequestDTO>(createAccount);
                return resutl;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> GetAccountInfoByEmail(string email)
        {
            var data = await _accountRepo.GetAccountDetailByEmail(email);
            return data;
        }

        public async Task<List<UserRequestDTO>> GetAllUserAscyn()
        {
            try
            {
                var account = await _accountRepo.GetAllAccount();
                var map = _mapper.Map<List<UserRequestDTO>>(account);
                return map;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}

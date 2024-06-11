using AutoMapper;
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
    public class PetRecordServices : IPetRecordServices
    {
        private readonly IPetRecordRepository _petRecordRepository;
        private readonly IPetRepository _petRepository;
        private readonly IVetRepository _vetRepository;
        private readonly IMapper _mapper;

        public PetRecordServices(IPetRecordRepository petRecordRepository, IPetRepository petRepository, IMapper mapper, IVetRepository vetRepository)
        {
            _petRecordRepository = petRecordRepository;
            _petRepository = petRepository;
            _vetRepository = vetRepository;
            _mapper = mapper;
        }

        public async Task<PetRecordResponseDTO> GetPetRecordByPetOrVetID(int petid)
        {
            try
            {
                var petData = await _petRepository.GetById(petid);
                if (petData == null)
                {
                    throw new Exception("Pet not Found");
                }
                var data = await _petRecordRepository.getByPetId(petid);
                var result = _mapper.Map<PetRecordResponseDTO>(petData);
                result.petRecordDTOs = _mapper.Map<List<PetRecordDTO>>(data);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

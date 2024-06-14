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
    public class KennelRecordService : IKennelRecordService
    {
        private readonly IKennelRepository kennelRepository;
        private readonly IPetRepository petRepository;
        private readonly IKennelRecordRepository kennelRecordRepository;
        private readonly IMapper mapper;

        public KennelRecordService(IKennelRepository kennelRepository, IPetRepository petRepository, IKennelRecordRepository kennelRecordRepository, IMapper mapper)
        {
            this.kennelRepository = kennelRepository;
            this.petRepository = petRepository;
            this.kennelRecordRepository = kennelRecordRepository;
            this.mapper = mapper;
        }

        public async Task<string> ReservationKennelRecord(KennelRecordRequestDTO dto)
        {
            try
            {
                var kennel = await kennelRepository.GetById(dto.KennelId);
                var pet = await petRepository.GetById(dto.PetId);
                if (kennel == null)
                {
                    return "Not found kennel!";
                }
                else if(pet == null)
                {
                    return "Not found Pet!";
                }
                else
                {
                    var kennelRecord = mapper.Map<KennelRecord>(dto);

                    kennelRecord.status = true;
                    kennelRecordRepository.AddkennelRecord(kennelRecord);

                    kennel.status = false;
                    kennelRepository.UpdateKennel(kennel);

                    return "Reservation kennel successful!";
                }
            }catch (Exception ex)
            {
                throw new Exception("Error database!");
            }
        }

        public async Task<List<KennelRecordResponseDTO>> GetAll()
        {
            try
            {
                List<KennelRecordResponseDTO> data = new List<KennelRecordResponseDTO>();
                var listKennelRecord = await kennelRecordRepository.GetAll();
                foreach (var item in listKennelRecord)
                {
                    var kennelRecord = mapper.Map<KennelRecordResponseDTO>(item);
                    var kennel = await kennelRepository.GetById(item.KennelId);
                    kennelRecord.KennelName = kennel != null ? kennel.Name : "error";
                    kennelRecord.kennelRoom = kennel != null ? kennel.RoomNumber : 0;
                    var pet = await petRepository.GetById(item.PetId);
                    kennelRecord.PetName = pet != null ? pet.PetName : "error";
                    data.Add(kennelRecord);
                }
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }         
        }

        public async Task<string> AddKennelRecord(KennelRecordRequestDTO dto)
        {
            try
            {
                var kennel = await kennelRepository.GetById(dto.KennelId);
                var pet = await petRepository.GetById(dto.PetId);
                if (kennel == null)
                {
                    return "Not found kennel!";
                }
                else if (pet == null)
                {
                    return "Not found Pet!";
                }
                else
                {
                    var kennelRecord = mapper.Map<KennelRecord>(dto);

                    kennelRecord.status = true;
                    kennelRecord.CheckInDate = DateTime.Now;
                    kennelRecordRepository.AddkennelRecord(kennelRecord);

                    kennel.status = false;
                    kennelRepository.UpdateKennel(kennel);

                    return "Add kennel successful!";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error database!");
            }
        }

        public async Task<string> UpdateKennelRecord(KennelRecordRequestDTO dto)
        {
            try
            {
                var kennelRecord = await kennelRecordRepository.GetById(dto.Id);
                var kennel = await kennelRepository.GetById(dto.KennelId);
                var pet = await petRepository.GetById(dto.PetId);
                if(kennelRecord == null)
                {
                    return "Not found KennelRecord!";
                }else if (kennel == null)
                {
                    return "Not found kennel!";
                }
                else if (pet == null)
                {
                    return "Not found Pet!";
                }
                else
                {
                    var oleKennel = await kennelRepository.GetById(kennelRecord.KennelId);
                    if(kennel != oleKennel)
                    {
                        if (kennel.status == false)
                        {
                            return "kennel is in use!";
                        }

                        oleKennel.status = true;
                        await kennelRepository.UpdateKennel(oleKennel);

                        kennel.status = false;
                        await kennelRepository.UpdateKennel(kennel);
                    }
                    var data =  mapper.Map(dto, kennelRecord);
                    await kennelRecordRepository.UpdateKennelRecord(data);
                    return "Update kennel successful!";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error database!");
            }
        }
    }
}

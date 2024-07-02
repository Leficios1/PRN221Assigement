using AutoMapper;
using BussinessObject.DTOs.Request;
using BussinessObject.DTOs.Response;
using BussinessObject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapping
{
    public class MappingEntites : Profile
    {
        public MappingEntites()
        {
            //User
            CreateMap<UserResponseDTO, User>().ReverseMap();
            CreateMap<UserResponseDTO, UserRequestDTO>().ReverseMap();
            CreateMap<UserRequestDTO, User>().ReverseMap();
            //Pet
            CreateMap<PetResponseDTO, PetRequestDTO>().ReverseMap();
            CreateMap<PetRequestDTO, Pet>().ReverseMap();
            CreateMap<PetResponseDTO, Pet>().ReverseMap();
            CreateMap<Pet, PetRecordResponseDTO>().ReverseMap();
            CreateMap<PetRecord, PetRecordDTO>().ReverseMap();
            CreateMap<PetRecordResponseDTO, PetResponseDTO>().ReverseMap();

            //Kennel
            CreateMap<KennelRequestDTO, KennelResponseDTO>().ReverseMap();
            CreateMap<KennelRequestDTO, Kennel>().ReverseMap();
            CreateMap<KennelResponseDTO, Kennel>().ReverseMap();
            //KennelRecord
            CreateMap<KennelRecordRequestDTO, KennelRecordResponseDTO>().ReverseMap();
            CreateMap<KennelRecordRequestDTO, KennelRecord>().ReverseMap();
            CreateMap<KennelRecordResponseDTO, KennelRecord>().ReverseMap();

            //Booking
            CreateMap<BookingRequestDTO, Booking>().ReverseMap();
            CreateMap<BookingDetailsRequestDTO, BookingDetails>().ReverseMap();
            CreateMap<Booking, BookingResponseDTO>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.bookingDetails, opt => opt.MapFrom(src => src.BookingDetails)).ReverseMap();

            //Booking Details
            CreateMap<BookingDetails, BookingDetailsDTO>()
                .ForMember(dest => dest.PetName, opt => opt.MapFrom(src => src.Pet.PetName))
                .ForMember(dest => dest.VetName, opt => opt.MapFrom(src => src.vet.Name))
                .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.service.ServiceName)).ReverseMap();
        }
    }
}

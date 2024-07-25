using AutoMapper;
using BussinessObject.DTOs.Request;
using BussinessObject.DTOs.Response;
using BussinessObject.Model.Entities;
using DataAccessObject.Repository.Interface;
using Microsoft.Extensions.Logging;
using Services.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Services.Services
{
    public class BookingServices : IBookingServices
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public BookingServices(IBookingRepository bookingRepository, IMapper mapper, IUserRepository userRepository)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<List<int>> BookingPerDays()
        {
            try
            {
                return await _bookingRepository.bookingPerDay();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> countBooking()
        {
            try
            {
                return await _bookingRepository.countBooking();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> createBooking(BookingRequestDTO dto)
        {
            try
            {
                foreach (var bookingDetail in dto.bookingDetails)
                {
                    var checkVetDateTime = await _bookingRepository.getDateTimeBookingByVetId(bookingDetail.VetId);

                    foreach (var date in checkVetDateTime)
                    {
                        if (Math.Abs((date - dto.Date).TotalMinutes) < 30 || (dto.Date - DateTime.Now).TotalMinutes < 30)
                        {
                            return false;
                        }
                    }
                }
                var flag = await _bookingRepository.createBooking(dto);
                return flag;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<BookingResponseDTO>> getAllBookingAsync()
        {
            try
            {
                var data = await _bookingRepository.getAllBookingAsync();
                var result = _mapper.Map<List<BookingResponseDTO>>(data);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<BookingResponseDTO>> getAllBookingProcessAsync()
        {
            try
            {
                var data = await _bookingRepository.getAllBookingProcessAsync();
                var result = _mapper.Map<List<BookingResponseDTO>>(data);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<BookingResponseDTO>> getAllBookingDoneAsync()
        {
            try
            {
                var data = await _bookingRepository.getAllBookingDoneAsync();
                var result = _mapper.Map<List<BookingResponseDTO>>(data);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<BookingResponseDTO>> getAllBookingByVetId(int vetId)
        {
            try
            {
                var data = await _bookingRepository.getAllBookingByVetId(vetId);
                var result = _mapper.Map<List<BookingResponseDTO>>(data);
                return result;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<BookingResponseDTO>> getBookingByUserId(int id)
        {
            try
            {
                var data = await _bookingRepository.getBookingByUserId(id);
                var result = _mapper.Map<List<BookingResponseDTO>>(data);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<BookingResponseDTO> getBookingDetailsByBookingId(int id)
        {
            try
            {
                var result = await _bookingRepository.getById(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<BookingResponseDTO>> getNewBookingByVetId(int vetId)
        {
            try
            {
                var data = await _bookingRepository.getNewBookingByVetId(vetId);
                var result = _mapper.Map<List<BookingResponseDTO>>(data);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> updateStatus(int bookingId)
        {
            try
            {
                var result = await _bookingRepository.updateStatus(bookingId);
                return result;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<BookingResponseDTO>getBookingById(int id)
        {
            try
            {
                var data = await _bookingRepository.getById(id);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

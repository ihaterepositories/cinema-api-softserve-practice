using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cinema.BLL.Helpers;
using Cinema.BLL.Services.Interfaces;
using Cinema.DAL.Infrastructure.Interfaces;
using Cinema.DAL.Repositories.Interfaces;
using Cinema.Data.DTOs.ReservationDTOs;
using Cinema.Data.Models;
using Cinema.Data.Responses.Interfaces;

namespace Cinema.BLL.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseCreator _responseCreator;

        private IReservationRepository Repository => _unitOfWork.ReservationRepository;

        public ReservationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _responseCreator = new ResponseCreator();
        }

        public async Task<IBaseResponse<List<GetReservationDto>>> GetAsync()
        {
            try
            {
                var reservationsFromDatabase = await Repository.GetAsync();

                if (reservationsFromDatabase.Count == 0)
                    return _responseCreator.CreateBaseNotFound<List<GetReservationDto>>("No reservations found.");

                var reservationsDto = _mapper.Map<List<GetReservationDto>>(reservationsFromDatabase);

                return _responseCreator.CreateBaseOk(reservationsDto, reservationsDto.Count);
            }
            catch (Exception e)
            {
                return _responseCreator.CreateBaseServerError<List<GetReservationDto>>(e.Message);
            }
        }

        public async Task<IBaseResponse<GetReservationDto>> GetByIdAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return _responseCreator.CreateBaseBadRequest<GetReservationDto>("Id is empty.");

                var reservationDto = _mapper.Map<GetReservationDto>(await Repository.GetByIdAsync(id));

                if (reservationDto == null)
                    return _responseCreator.CreateBaseNotFound<GetReservationDto>($"Reservation with id {id} not found.");

                return _responseCreator.CreateBaseOk(reservationDto, 1);
            }
            catch (Exception e)
            {
                return _responseCreator.CreateBaseServerError<GetReservationDto>(e.Message);
            }
        }

        public async Task<IBaseResponse<string>> InsertAsync(AddReservationDto entity)
        {
            try
            {
                if (entity == null)
                    return _responseCreator.CreateBaseBadRequest<string>("Reservation is empty.");

                await Repository.InsertAsync(_mapper.Map<Reservation>(entity));
                await _unitOfWork.SaveChangesAsync();

                return _responseCreator.CreateBaseOk($"Reservation added.", 1);
            }
            catch (Exception e)
            {
                return _responseCreator.CreateBaseServerError<string>(e.Message);
            }
        }

        public async Task<IBaseResponse<string>> UpdateAsync(UpdateReservationDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IBaseResponse<string>> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
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
        private IReservedSeatRepository ReservedSeatRepository => _unitOfWork.ReservedSeatRepository;

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
        
        public async Task<IBaseResponse<string>> AddReservationWithReservedSeats(AddReservationDto addReservationDto)
        {
            try
            {
                if (addReservationDto == null)
                    return _responseCreator.CreateBaseBadRequest<string>("Reservation is empty.");
                
                var reservation = _mapper.Map<Reservation>(addReservationDto);
                reservation.ReservedSeats = new List<ReservedSeat>();
                
                foreach (var addReservedSeatDto in addReservationDto.ReservedSeats)
                {
                    var existingReservedSeat = await ReservedSeatRepository.GetBySeatIdAndScreeningIdAsync(addReservedSeatDto.SeatId, addReservedSeatDto.ScreeningId);
                    if(existingReservedSeat == null)
                    {
                        var reservedSeat = _mapper.Map<ReservedSeat>(addReservedSeatDto);
                        reservedSeat.IsReserved = true;
                        await ReservedSeatRepository.InsertAsync(reservedSeat);
                        reservation.ReservedSeats.Add(reservedSeat);
                    }
                    else
                    {
                        if (existingReservedSeat.IsReserved)
                        {
                            return _responseCreator.CreateBaseBadRequest<string>(
                                $"Seat with number:{existingReservedSeat.Seat.Number} " +
                                $"row:{existingReservedSeat.Seat.Row} is already reserved.");
                        }
                            var reservedSeat = _mapper.Map<ReservedSeat>(addReservedSeatDto);
                            reservedSeat.IsReserved = true;
                            await ReservedSeatRepository.UpdateAsync(reservedSeat);
                            reservation.ReservedSeats.Add(reservedSeat);
                        
                    }
                }
                
                await Repository.InsertAsync(reservation);
                await _unitOfWork.SaveChangesAsync();

                return _responseCreator.CreateBaseOk($"Reservation added.", 1);
            }
            catch (Exception e)
            {
                return _responseCreator.CreateBaseServerError<string>(e.Message);
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
            try
            {
                if (entity == null)
                    return _responseCreator.CreateBaseBadRequest<string>("Genre is empty.");

                await Repository.UpdateAsync(_mapper.Map<Reservation>(entity));
                await _unitOfWork.SaveChangesAsync();

                return _responseCreator.CreateBaseOk("Reservation updated.", 1);
            }
            catch (Exception e)
            {
                return _responseCreator.CreateBaseServerError<string>(e.Message);
            }
        }

        public async Task<IBaseResponse<string>> DeleteAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return _responseCreator.CreateBaseBadRequest<string>("Id is empty.");

                await Repository.DeleteAsync(id);
                await _unitOfWork.SaveChangesAsync();

                return _responseCreator.CreateBaseOk("Reservation deleted.", 1);
            }
            catch (Exception e)
            {
                return _responseCreator.CreateBaseServerError<string>(e.Message);
            }
        }
    }
}
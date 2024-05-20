using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Data.DTOs.ReservationDTOs;
using Cinema.Data.Responses.Interfaces;

namespace Cinema.BLL.Services.Interfaces
{
    public interface IReservationService
    {
        Task<IBaseResponse<List<GetReservationDto>>> GetAsync();
        Task<IBaseResponse<GetReservationDto>> GetByIdAsync(Guid id);
        Task<IBaseResponse<string>> AddReservationWithReservedSeats(AddReservationDto addReservationDto);
        Task<IBaseResponse<string>> InsertAsync(AddReservationDto entity);
        Task<IBaseResponse<string>> UpdateAsync(UpdateReservationDto entity);
        Task<IBaseResponse<string>> DeleteAsync(Guid id);
    }
}
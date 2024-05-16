using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Data.DTOs.SeatDTOs;
using Cinema.Data.Responses.Interfaces;

namespace Cinema.BLL.Services.Interfaces;

public interface ISeatService
{
    Task<IBaseResponse<List<GetSeatDto>>> GetAsync();
    Task<IBaseResponse<GetSeatDto>> GetByIdAsync(Guid id);

    Task<IBaseResponse<List<GetSeatDto>>> GetSeatsByScreeningIdAsync(Guid id);
    Task<IBaseResponse<string>> InsertAsync(AddSeatDto entity);
    Task<IBaseResponse<string>> UpdateAsync(UpdateSeatDto entity);
    Task<IBaseResponse<string>> DeleteAsync(Guid id);
}
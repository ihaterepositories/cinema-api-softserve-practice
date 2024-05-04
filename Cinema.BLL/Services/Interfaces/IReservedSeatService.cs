using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Data.DTOs.ReservedSeatDTOs;
using Cinema.Data.Responses.Interfaces;

namespace Cinema.BLL.Services.Interfaces;

public interface IReservedSeatService
{
    Task<IBaseResponse<List<GetReservedSeatDto>>> GetAsync();
    Task<IBaseResponse<GetReservedSeatDto>> GetByIdAsync(Guid id);
    Task<IBaseResponse<string>> InsertAsync(AddReservedSeatDto entity);
    Task<IBaseResponse<string>> DeleteAsync(Guid id);
}
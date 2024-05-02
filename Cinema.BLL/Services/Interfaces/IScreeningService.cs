using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Data.DTOs.ScreeningDTOs;
using Cinema.Data.Responses.Interfaces;

namespace Cinema.BLL.Services.Interfaces;

public interface IScreeningService
{
    Task<IBaseResponse<List<GetScreeningDto>>> GetAsync();
    Task<IBaseResponse<GetScreeningDto>> GetByIdAsync(Guid id);
    Task<IBaseResponse<string>> InsertAsync(AddScreeningDto entity);
    Task<IBaseResponse<string>> UpdateAsync(UpdateScreeningDto entity);
    Task<IBaseResponse<string>> DeleteAsync(Guid id);
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Data.DTOs.ScreeningDTOs;
using Cinema.Data.Responses.Interfaces;

namespace Cinema.BLL.Services.Interfaces;

public interface IScreeningService
{
    Task<IBaseResponse<List<GetScreeningDto>>> GetActualAsync();
    Task<IBaseResponse<List<GetScreeningDto>>> GetActualByMovieNameAsync(string movieName);
    Task<IBaseResponse<List<GetScreeningDto>>> GetActualByDurationAsync(string minDuration, string maxDuration);
    Task<IBaseResponse<List<GetScreeningDto>>> GetActualByDateAsync(DateOnly date);
    Task<IBaseResponse<List<GetScreeningDto>>> GetScreeningsByRoomId(Guid id);
    Task<IBaseResponse<List<GetScreeningDto>>> GetActualByDurationAsync(string minDuration,string maxDuration);
    Task<IBaseResponse<List<GetScreeningDto>>> GetActualByDateAsync(DateOnly date);
    Task<IBaseResponse<List<GetScreeningDto>>> GetAsync();
    Task<IBaseResponse<GetScreeningDto>> GetByIdAsync(Guid id);
    Task<IBaseResponse<string>> InsertAsync(AddScreeningDto entity);
    Task<IBaseResponse<string>> UpdateAsync(UpdateScreeningDto entity);
    Task<IBaseResponse<string>> DeleteAsync(Guid id);
}
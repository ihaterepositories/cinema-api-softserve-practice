using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Data.DTOs.GenreDTOs;
using Cinema.Data.Responses.Interfaces;

namespace Cinema.BLL.Services.Interfaces;

public interface IGenreService
{
    Task<IBaseResponse<List<GetGenreDto>>> GetAsync();
    Task<IBaseResponse<GetGenreDto>> GetByIdAsync(Guid id);
    Task<IBaseResponse<string>> InsertAsync(AddGenreDto entity);
    Task<IBaseResponse<string>> UpdateAsync(UpdateGenreDto entity);
    Task<IBaseResponse<string>> DeleteAsync(Guid id);
}
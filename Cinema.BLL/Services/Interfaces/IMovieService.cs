using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Data.DTOs.MovieDTOs;
using Cinema.Data.Responses.Interfaces;

namespace Cinema.BLL.Services.Interfaces
{
    public interface IMovieService
    {
        Task<IBaseResponse<List<GetMovieDto>>> GetAsync();

        Task<IBaseResponse<List<GetMovieDto>>> GetNewMoviesAsync();
        Task<IBaseResponse<GetMovieDto>> GetByIdAsync(Guid id);
        Task<IBaseResponse<string>> InsertAsync(AddMovieDto entity);
        Task<IBaseResponse<string>> UpdateAsync(UpdateMovieDto entity);
        Task<IBaseResponse<string>> DeleteAsync(Guid id);
    }
}
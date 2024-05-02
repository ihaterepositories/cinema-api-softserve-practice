using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Data.DTOs.MovieDTOs;

namespace Cinema.BLL.Services.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<GetMovieDto>> GetAsync();
        Task<GetMovieDto> GetByIdAsync(Guid id);
        Task InsertAsync(AddMovieDto entity);
        Task UpdateAsync(UpdateMovieDto entity);
        Task DeleteAsync(Guid id);
    }
}
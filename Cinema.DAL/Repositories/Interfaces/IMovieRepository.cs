using System.Linq.Expressions;
using Cinema.DAL.Infrastructure.Interfaces;
using Cinema.Data.Models;

namespace Cinema.DAL.Repositories.Interfaces;

public interface IMovieRepository : IGenericRepository<Movie>
{
    new Task<List<Movie>> GetAsync();
    new Task<Movie> GetByIdAsync(Guid id);
    
    Task<List<Movie>> GetTakeSkipAsync(int take, int skip);
    Task<List<Movie>> GetTakeSkipSortByAsync(int take, int skip, string sortBy);
    Task<List<Movie>> GetUserWatchedMoviesAsync(Guid userId);
}
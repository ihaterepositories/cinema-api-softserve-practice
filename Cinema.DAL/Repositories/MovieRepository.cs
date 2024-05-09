using Cinema.DAL.Infrastructure;
using Cinema.DAL.Repositories.Interfaces;
using Cinema.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DAL.Repositories;

public class MovieRepository : GenericRepository<Movie>, IMovieRepository
{
    public MovieRepository(CinemaContext context) : base(context)
    {

    }

    public override async Task<List<Movie>> GetAsync()
    {
        IQueryable<Movie> query = DatabaseContext.Movies;

        // Include related entities
        query = query.Include(c => c.MovieActors).ThenInclude(c => c.Actor);
        query = query.Include(c => c.MovieGenres).ThenInclude(c => c.Genre); ;

        var result = await query.ToListAsync();
        return result;
    }

    public override async Task<Movie> GetByIdAsync(Guid id)
    {
        IQueryable<Movie> query = DatabaseContext.Movies;

        // Include related entities
        query = query.Include(c => c.MovieActors).ThenInclude(c => c.Actor);
        query = query.Include(c => c.MovieGenres).ThenInclude(c => c.Genre);
        Movie? result = await query.FirstOrDefaultAsync(m => m.Id == id);
        return result;
    }
}
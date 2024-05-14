using Cinema.DAL.Infrastructure;
using Cinema.DAL.Repositories.Interfaces;
using Cinema.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DAL.Repositories;

public class MovieRepository : GenericRepository<Movie>, IMovieRepository
{
    private readonly CinemaContext _context;
    public MovieRepository(CinemaContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<List<Movie>> GetTakeSkipAsync(int take, int skip)
    {
        return await _context.Movies
            .OrderBy(m => m.Id) // Order by some property if needed
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }
    
    public async Task<List<Movie>> GetTakeSkipSortByAsync(int take, int skip, string sortBy)
    {
        IQueryable<Movie> query = _context.Movies;

        switch (sortBy.ToLower())
        {
            case "title":
                query = query.OrderBy(m => m.Name);
                break;
            case "releaseDate":
                query = query.OrderBy(m => m.ReleaseDate);
                break;
            case "rating":
                query = query.OrderBy(m => m.Rating);
                break;
            default:
                query = query.OrderBy(m => m.Id); 
                break;
        }

        return await query.Skip(skip).Take(take).ToListAsync();
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
using Cinema.DAL.Infrastructure;
using Cinema.DAL.Repositories.Interfaces;
using Cinema.Data.Models;

namespace Cinema.DAL.Repositories;

public class MovieGenreRepository : GenericRepository<MovieGenre>, IMovieGenreRepository
{
    public MovieGenreRepository(CinemaContext context) : base(context)
    {
    }
}
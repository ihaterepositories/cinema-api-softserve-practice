using Cinema.DAL.Infrastructure;
using Cinema.DAL.Repositories.Interfaces;
using Cinema.Data.Models;

namespace Cinema.DAL.Repositories;

public class MovieActorRepository : GenericRepository<MovieActor>, IMovieActorRepository
{
    public MovieActorRepository(CinemaContext context) : base(context)
    {
    }
}
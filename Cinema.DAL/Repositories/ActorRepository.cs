using Cinema.DAL.Infrastructure;
using Cinema.DAL.Repositories.Interfaces;
using Cinema.Data.Models;

namespace Cinema.DAL.Repositories;

public class ActorRepository : GenericRepository<Actor>, IActorRepository
{
    public ActorRepository(CinemaContext context) : base(context)
    {
    }
}
using Cinema.DAL.Infrastructure;
using Cinema.DAL.Repositories.Interfaces;
using Cinema.Data.Models;

namespace Cinema.DAL.Repositories;

public class ScreeningRepository : GenericRepository<Screening>, IScreeningRepository
{
    public ScreeningRepository(CinemaContext context) : base(context)
    {
    }
}
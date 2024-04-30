using Cinema.DAL.Infrastructure;
using Cinema.DAL.Repositories.Interfaces;
using Cinema.Data.Models;

namespace Cinema.DAL.Repositories;

public class SeatRepository : GenericRepository<Seat>, ISeatRepository
{
    public SeatRepository(CinemaContext context) : base(context)
    {
    }
}
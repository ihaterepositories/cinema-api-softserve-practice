using Cinema.DAL.Infrastructure;
using Cinema.DAL.Repositories.Interfaces;
using Cinema.Data.Models;

namespace Cinema.DAL.Repositories;

public class ReservedSeatRepository : GenericRepository<ReservedSeat>, IReservedSeatRepository
{
    public ReservedSeatRepository(CinemaContext context) : base(context)
    {
    }
}
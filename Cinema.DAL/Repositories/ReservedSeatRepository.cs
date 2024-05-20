using Cinema.DAL.Infrastructure;
using Cinema.DAL.Repositories.Interfaces;
using Cinema.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DAL.Repositories;

public class ReservedSeatRepository : GenericRepository<ReservedSeat>, IReservedSeatRepository
{
    public ReservedSeatRepository(CinemaContext context) : base(context)
    {
    }

    public virtual async Task<ReservedSeat?> GetBySeatIdAndScreeningIdAsync(Guid seatId, Guid screeningId)
    {
        return await Table.Where(x => x.SeatId == seatId && x.ScreeningId == screeningId).FirstOrDefaultAsync();
    }
}
using Cinema.DAL.Infrastructure.Interfaces;
using Cinema.Data.Models;

namespace Cinema.DAL.Repositories.Interfaces;

public interface IReservedSeatRepository : IGenericRepository<ReservedSeat>
{
    Task<ReservedSeat?> GetBySeatIdAndScreeningIdAsync(Guid seatId,Guid screeningId);
}
using Cinema.DAL.Infrastructure;
using Cinema.DAL.Repositories.Interfaces;
using Cinema.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DAL.Repositories;

public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
{
    public ReservationRepository(CinemaContext context) : base(context)
    {

    }
    public override async Task<List<Reservation>> GetAsync()
    {
        IQueryable<Reservation> query = DatabaseContext.Reservations;

        // Include related entities
        query = query.Include(c => c.ReservedSeats).ThenInclude(c => c.Seat);
        query = query.Include(c => c.ReservedSeats).ThenInclude(c => c.Screening);
        return await query.ToListAsync();
    }

    public override async Task<Reservation> GetByIdAsync(Guid id)
    {
        IQueryable<Reservation> query = DatabaseContext.Reservations;

        // Include related entities
        query = query.Include(c => c.ReservedSeats).ThenInclude(c => c.Seat);
        query = query.Include(c => c.ReservedSeats).ThenInclude(c => c.Screening);

        return await query.FirstOrDefaultAsync(m => m.Id == id);
    }
}
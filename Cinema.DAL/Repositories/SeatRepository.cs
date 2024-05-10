using Cinema.DAL.Infrastructure;
using Cinema.DAL.Repositories.Interfaces;
using Cinema.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DAL.Repositories;

public class SeatRepository : GenericRepository<Seat>, ISeatRepository
{
    public SeatRepository(CinemaContext context) : base(context)
    {
    }

    public override async Task<List<Seat>> GetAsync()
    {
        IQueryable<Seat> query = DatabaseContext.Seats;

        // Include related entities
        query = query.Include(c => c.ReservedSeats);
        return await query.ToListAsync();
    }

    public override async Task<Seat> GetByIdAsync(Guid id)
    {
        IQueryable<Seat> query = DatabaseContext.Seats;

        // Include related entities
        query = query.Include(c => c.ReservedSeats);

        return await query.FirstOrDefaultAsync(m => m.Id == id);
    }
}
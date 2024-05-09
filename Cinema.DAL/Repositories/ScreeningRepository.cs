using Cinema.DAL.Infrastructure;
using Cinema.DAL.Repositories.Interfaces;
using Cinema.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DAL.Repositories;

public class ScreeningRepository : GenericRepository<Screening>, IScreeningRepository
{
    public ScreeningRepository(CinemaContext context) : base(context)
    {
    }

    public override async Task<List<Screening>> GetAsync()
    {
        var screenings = await DatabaseContext.Screenings
            .Include(c => c.Room).ThenInclude(c => c.Seats)
            .ToListAsync();

        var screeningIds = screenings.Select(s => s.Id).ToList();
        var reservedSeats = await DatabaseContext.ReservedSeats
            .Where(r => screeningIds.Contains(r.ScreeningId))
            .ToListAsync();

        foreach (var screening in screenings)
        {
            screening.ReservedSeats = reservedSeats.Where(r => r.ScreeningId == screening.Id).ToList();
        }

        return screenings;
    }

    public override async Task<Screening> GetByIdAsync(Guid id)
    {
        var screening = await DatabaseContext.Screenings
            .Include(c => c.Room).ThenInclude(c => c.Seats)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (screening != null)
        {
            var reservedSeats = await DatabaseContext.ReservedSeats
                .Where(s => s.ScreeningId == id)
                .ToListAsync();

            screening.ReservedSeats = reservedSeats;
        }

        return screening;
    }
}
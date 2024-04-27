using Cinema.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.DAL.Configurations;

public class ScreeningConfiguration : IEntityTypeConfiguration<Screening>
{
    public void Configure(EntityTypeBuilder<Screening> builder)
    {
        builder.HasKey(s => s.Id);

        builder.HasOne(s => s.Movie)
            .WithMany(m => m.Screenings)
            .HasForeignKey(s => s.MovieId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(s => s.Room)
            .WithMany(r => r.Screenings)
            .HasForeignKey(s => s.RoomId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(s => s.ReservedSeats)
            .WithOne(rs => rs.Screening)
            .HasForeignKey(rs => rs.ScreeningId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
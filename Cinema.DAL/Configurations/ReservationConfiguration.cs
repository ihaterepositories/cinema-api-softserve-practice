using Cinema.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.DAL.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasKey(r => r.Id);

        builder.HasMany(r => r.ReservedSeats)
            .WithOne()
            .HasForeignKey(rs => rs.ReservationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
using Cinema.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.DAL.Configurations;

public class ReservedSeatConfiguration : IEntityTypeConfiguration<ReservedSeat>
{
    public void Configure(EntityTypeBuilder<ReservedSeat> builder)
    {
        builder.HasKey(rs => rs.Id);

        builder.HasOne(rs => rs.Reservation)
            .WithMany(r => r.ReservedSeats)
            .HasForeignKey(rs => rs.ReservationId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(rs => rs.Seat)
            .WithMany()
            .HasForeignKey(rs => rs.SeatId);

        builder.HasOne(rs => rs.Screening)
            .WithMany()
            .HasForeignKey(rs => rs.ScreeningId);
    }
}
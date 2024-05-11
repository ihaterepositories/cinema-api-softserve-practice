namespace Cinema.Data.Models;

public class ReservedSeat
{
    public Guid Id { get; set; }
    public Guid ReservationId { get; set; }
    public Guid SeatId { get; set; }
    public Guid ScreeningId { get; set; }
    public bool IsReserved { get; set; }
    
    public Reservation Reservation { get; set; } = null!;
    public Seat Seat { get; set; } = null!;
    public Screening Screening { get; set; } = null!;
}
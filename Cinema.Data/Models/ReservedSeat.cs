using System.ComponentModel.DataAnnotations;

namespace Cinema.Data.Models;

public class ReservedSeat
{
    public Guid Id { get; set; }
    
    [Required]
    public Guid ReservationId { get; set; }
    
    [Required]
    public Guid SeatId { get; set; }
    
    [Required]
    public Guid ScreeningId { get; set; }
    
    [Required]
    public bool IsReserved { get; set; }
    
    public Reservation Reservation { get; set; } = null!;
    public Seat Seat { get; set; } = null!;
    public Screening Screening { get; set; } = null!;
}
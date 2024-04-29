namespace Cinema.Data.Models;

public class Reservation
{
    public Guid Id { get; set; }
    public bool Reserved { get; set; }
    public Guid UserId { get; set; }
    public bool IsPaid { get; set; }
    public bool IsActive { get; set; }

    public ICollection<ReservedSeat> ReservedSeats { get; set; } = null!;
    public User User { get; set; } = null!;
}
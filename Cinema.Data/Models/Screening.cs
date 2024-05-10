namespace Cinema.Data.Models;

public class Screening
{
    public Guid Id { get; set; }
    public Guid MovieId { get; set; }
    public Guid RoomId { get; set; }
    public DateTime StartDateTime { get; set; }
    public double Price { get; set; }
    
    public ICollection<ReservedSeat> ReservedSeats { get; set; } = null!;
    public Movie Movie { get; set; } = null!;
    public Room Room { get; set; } = null!;
}
namespace Cinema.Data.Models;

public class Seat
{
    public Guid Id { get; set; }
    public int Row { get; set; }
    public int Number { get; set; }
    public Guid RoomId { get; set; }
    
    public ICollection<ReservedSeat> ReservedSeats { get; set; } = null!;
    public Room Room { get; set; } = null!;
}
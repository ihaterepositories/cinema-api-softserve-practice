namespace Cinema.Data.Models;

public class Room
{
    public Guid Id { get; set; }
    public string RoomName { get; set; } = string.Empty;
    public int NumberOfSeats { get; set; }
    
    public ICollection<Screening> Screenings { get; set; } = null!;
    public ICollection<Seat> Seats { get; set; } = null!;
}
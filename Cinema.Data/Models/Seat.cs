using System.ComponentModel.DataAnnotations;

namespace Cinema.Data.Models;

public class Seat
{
    public Guid Id { get; set; }
    
    [Range(1, 5)]
    public int Row { get; set; }
    
    [Range(1, 10)]
    public int Number { get; set; }
    
    [Required]
    public Guid RoomId { get; set; }
    
    public ICollection<ReservedSeat> ReservedSeats { get; set; } = null!;
    public Room Room { get; set; } = null!;
}
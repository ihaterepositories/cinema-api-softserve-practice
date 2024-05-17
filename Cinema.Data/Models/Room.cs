using System.ComponentModel.DataAnnotations;

namespace Cinema.Data.Models;

public class Room
{
    public Guid Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string RoomName { get; set; } = string.Empty;
    
    [Range(1, 50)]
    public int NumberOfSeats { get; set; }
    
    public ICollection<Screening> Screenings { get; set; } = null!;
    public ICollection<Seat> Seats { get; set; } = null!;
}
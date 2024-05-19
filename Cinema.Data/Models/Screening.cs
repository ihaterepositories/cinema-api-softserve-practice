using System.ComponentModel.DataAnnotations;

namespace Cinema.Data.Models;

public class Screening
{
    public Guid Id { get; set; }
    
    [Required]
    public Guid MovieId { get; set; }
    
    [Required]
    public Guid RoomId { get; set; }
    
    [Required]
    public DateTime StartDateTime { get; set; }
    
    [Required]
    [Range(0, double.MaxValue)]
    public double Price { get; set; }
    
    public ICollection<ReservedSeat> ReservedSeats { get; set; } = null!;
    public Movie Movie { get; set; } = null!;
    public Room Room { get; set; } = null!;
}
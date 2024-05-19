using System.ComponentModel.DataAnnotations;

namespace Cinema.Data.Models;

public class Genre
{
    public Guid Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string GenreName { get; set; } = string.Empty;
    
    public ICollection<MovieGenre> MovieGenres { get; set; } = null!;
}
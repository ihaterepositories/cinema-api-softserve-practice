namespace Cinema.Data.Models;

public class Genre
{
    public Guid Id { get; set; }
    public string GenreName { get; set; } = string.Empty;
    
    public ICollection<MovieGenre> MovieGenres { get; set; } = null!;
}
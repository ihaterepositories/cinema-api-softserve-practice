namespace Cinema.Data.Models;

public class MovieGenre
{
    public Guid MovieId { get; set; }
    public Guid GenreId { get; set; }
    
    public Movie Movie { get; set; } = null!;
    public Genre Genre { get; set; } = null!;
}
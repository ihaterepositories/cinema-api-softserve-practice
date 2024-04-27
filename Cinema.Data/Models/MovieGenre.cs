namespace Cinema.Data.Models;

public class MovieGenre
{
    public Guid MovieId { get; set; }
    public Guid GenreId { get; set; }
    
    public virtual Movie Movie { get; set; } = null!;
    public virtual Genre Genre { get; set; } = null!;
}
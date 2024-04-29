namespace Cinema.Data.Models;

public class MovieActor
{
    public Guid MovieId { get; set; }
    public Guid ActorId { get; set; }
    
    public Movie Movie { get; set; } = null!;
    public Actor Actor { get; set; } = null!;
}
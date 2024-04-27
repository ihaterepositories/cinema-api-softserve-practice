namespace Cinema.Data.Models;

public class Movie
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateOnly ReleaseDate { get; set; }
    public double Rating { get; set; }
    public DateOnly StartAiringDate { get; set; }
    public DateOnly EndAiringDate { get;set; }
    public string Description { get; set; } = string.Empty;
    public string Trailer { get; set; } = string.Empty;
    public TimeOnly Duration { get; set; }
    public string Photo {  get; set; } = string.Empty;
    
    public ICollection<MovieActor> MovieActors { get; set; } = null!;
    public ICollection<MovieGenre> MovieGenres { get; set; } = null!;
    public ICollection<Screening> Screenings { get; set; } = null!;
}
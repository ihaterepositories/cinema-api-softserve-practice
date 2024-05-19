using System.ComponentModel.DataAnnotations;

namespace Cinema.Data.Models;

public class Movie
{
    public Guid Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public DateOnly ReleaseDate { get; set; }

    [Range(0, 10)]
    public double Rating { get; set; }

    [Required]
    public DateOnly StartAiringDate { get; set; }

    [Required]
    public DateOnly EndAiringDate { get;set; }

    [StringLength(500)]
    public string Description { get; set; } = string.Empty;

    [Url]
    public string Trailer { get; set; } = string.Empty;

    [Required]
    public TimeOnly Duration { get; set; }

    [Url]
    public string Photo {  get; set; } = string.Empty;
    
    public ICollection<MovieActor> MovieActors { get; set; } = null!;
    public ICollection<MovieGenre> MovieGenres { get; set; } = null!;
    public ICollection<Screening> Screenings { get; set; } = null!;
}
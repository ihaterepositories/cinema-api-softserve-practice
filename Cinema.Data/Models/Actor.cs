using System.ComponentModel.DataAnnotations;

namespace Cinema.Data.Models;

public class Actor
{
    public Guid Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string FullName { get; set; } = string.Empty;
    
    [StringLength(500)]
    public string Description { get; set; } = string.Empty;
    
    [Url]
    public string Photo { get; set; } = string.Empty;

    public List<MovieActor> MovieActors { get; set; } = null!;
}
namespace Cinema.Data.Models;

public class Actor
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Photo { get; set; } = string.Empty;

    public List<MovieActor> MovieActors { get; set; } = null!;
}
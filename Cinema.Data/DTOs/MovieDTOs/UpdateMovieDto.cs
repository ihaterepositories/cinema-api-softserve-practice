namespace Cinema.Data.DTOs.MovieDTOs
{
    public class UpdateMovieDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly ReleaseDate { get; set; }
        public double Rating { get; set; }
        public DateOnly StartAiringDate { get; set; }
        public DateOnly EndAiringDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Trailer { get; set; } = string.Empty;
        public TimeOnly Duration { get; set; }
        public string Photo { get; set; } = string.Empty;
        public List<AddMovieActorDto> MovieActors { get; set; } = null!;
        public List<AddMovieGenreDto> MovieGenres { get; set; } = null!;
    }
}
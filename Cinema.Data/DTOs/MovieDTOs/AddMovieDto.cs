namespace Cinema.Data.DTOs.MovieDTOs
{
    public class AddMovieDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public double Rating { get; set; }
        public DateTime StartAiringDate { get; set; }
        public DateTime EndAiringDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Trailer { get; set; } = string.Empty;
        public TimeSpan Duration { get; set; }
        public string Photo { get; set; } = string.Empty;
        public List<AddMovieActorDto> MovieActors { get; set; } = null!;
        public List<AddMovieGenreDto> MovieGenres { get; set; } = null!;
    }
}
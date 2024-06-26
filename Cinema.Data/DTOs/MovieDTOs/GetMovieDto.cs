using Cinema.Data.DTOs.ActorDTOs;
using Cinema.Data.DTOs.GenreDTOs;

namespace Cinema.Data.DTOs.MovieDTOs
{
    public class GetMovieDto
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

        public List<GetActorDto> MovieActors { get; set; } = null!;
        public List<GetGenreDto> MovieGenres { get; set; } = null!;
    }
}
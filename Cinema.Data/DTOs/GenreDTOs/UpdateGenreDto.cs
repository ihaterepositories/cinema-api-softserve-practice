namespace Cinema.Data.DTOs.GenreDTOs
{
    public class UpdateGenreDto
    {
        public Guid Id { get; set; }
        public string GenreName { get; set; } = string.Empty;
    }
}
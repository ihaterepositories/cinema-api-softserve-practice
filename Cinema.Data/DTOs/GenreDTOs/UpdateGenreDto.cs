using System.ComponentModel.DataAnnotations;

namespace Cinema.Data.DTOs.GenreDTOs
{
    public class UpdateGenreDto
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string GenreName { get; set; } = string.Empty;
    }
}
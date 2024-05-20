using System.ComponentModel.DataAnnotations;

namespace Cinema.Data.DTOs.GenreDTOs
{
    public class AddGenreDto
    {
        [Required]
        [StringLength(100)]
        public string GenreName { get; set; } = string.Empty;
    }
}
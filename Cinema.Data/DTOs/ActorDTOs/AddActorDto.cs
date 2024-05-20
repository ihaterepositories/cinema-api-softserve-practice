using System.ComponentModel.DataAnnotations;

namespace Cinema.Data.DTOs.ActorDTOs
{
    public class AddActorDto
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [Url]
        public string Photo { get; set; } = string.Empty;
    }
}
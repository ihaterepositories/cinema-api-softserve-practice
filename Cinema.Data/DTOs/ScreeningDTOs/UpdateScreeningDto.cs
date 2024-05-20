using System.ComponentModel.DataAnnotations;

namespace Cinema.Data.DTOs.ScreeningDTOs
{
    public class UpdateScreeningDto
    {
        public Guid Id { get; set; }
        [Required]
        public Guid MovieId { get; set; }
        [Required]
        public Guid RoomId { get; set; }
        [Required]
        public DateTime StartDateTime { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
    }
}
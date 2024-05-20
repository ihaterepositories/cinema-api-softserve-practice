using System.ComponentModel.DataAnnotations;

namespace Cinema.Data.DTOs.SeatDTOs
{
    public class AddSeatDto
    {
        [Range(1, 5)]
        public int Row { get; set; }
        [Range(1, 10)]
        public int Number { get; set; }
        [Required]
        public Guid RoomId { get; set; }
    }
}
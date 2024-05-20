using System.ComponentModel.DataAnnotations;

namespace Cinema.Data.DTOs.RoomsDTOs
{
    public class AddRoomDto
    {
        [Required]
        [StringLength(100)]
        public string RoomName { get; set; } = string.Empty;
        [Range(1, 50)]
        public int NumberOfSeats { get; set; }
    }
}
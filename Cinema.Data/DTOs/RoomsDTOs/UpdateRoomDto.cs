using Cinema.Data.DTOs.ScreeningDTOs;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Data.DTOs.RoomsDTOs
{
    public class UpdateRoomDto
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string RoomName { get; set; } = string.Empty;
        [Range(1, 50)]
        public int NumberOfSeats { get; set; }
        public List<UpdateScreeningDto> Screenings { get; set; } = null!;
    }
}
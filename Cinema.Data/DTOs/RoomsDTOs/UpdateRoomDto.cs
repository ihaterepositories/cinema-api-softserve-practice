using Cinema.Data.DTOs.ScreeningDTOs;

namespace Cinema.Data.DTOs.RoomsDTOs
{
    public class UpdateRoomDto
    {
        public Guid Id { get; set; }
        public string RoomName { get; set; } = string.Empty;
        public int NumberOfSeats { get; set; }
        public List<UpdateScreeningDto> Screenings { get; set; } = null!;
    }
}
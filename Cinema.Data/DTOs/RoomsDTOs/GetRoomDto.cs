using Cinema.Data.DTOs.SeatDTOs;

namespace Cinema.Data.DTOs.RoomsDTOs
{
    public class GetRoomDto
    {
        public Guid Id { get; set; }
        public string RoomName { get; set; } = string.Empty;
        public int NumberOfSeats { get; set; }
        public ICollection<GetSeatDto> Seats { get; set; } = new List<GetSeatDto>();
    }
}
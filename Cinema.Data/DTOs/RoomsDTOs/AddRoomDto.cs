namespace Cinema.Data.DTOs.RoomsDTOs
{
    public class AddRoomDto
    {
        public string RoomName { get; set; } = string.Empty;
        public int NumberOfSeats { get; set; }
    }
}
namespace Cinema.Data.DTOs.SeatDTOs
{
    public class AddSeatDto
    {
        public int Row { get; set; }
        public int Number { get; set; }
        public Guid RoomId { get; set; }
    }
}
namespace Cinema.Data.DTOs.SeatDTOs
{
    public class GetSeatDto
    {
        public Guid Id { get; set; }
        public int Row { get; set; }
        public int Number { get; set; }
        public Guid RoomId { get; set; }
    }
}
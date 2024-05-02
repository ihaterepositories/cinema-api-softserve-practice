namespace Cinema.Data.DTOs.ScreeningDTOs
{
    public class UpdateScreeningDto
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public Guid RoomId { get; set; }
        public TimeOnly ScreeningStart { get; set; }
        public double Price { get; set; }
    }
}
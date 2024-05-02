namespace Cinema.Data.DTOs.ReservedSeatDTOs
{
    public class AddReservedSeatDto
    {
        public Guid ReservationId { get; set; }
        public Guid SeatId { get; set; }
        public Guid ScreeningId { get; set; }
    }
}
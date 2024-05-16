using Cinema.Data.DTOs.ScreeningDTOs;
using Cinema.Data.DTOs.SeatDTOs;

namespace Cinema.Data.DTOs.ReservedSeatDTOs
{
    public class GetReservedSeatDto
    {
        public Guid Id { get; set; }
        public Guid ReservationId { get; set; }
        public Guid SeatId { get; set; }
        public Guid ScreeningId { get; set; }
        public bool IsReserved {  get; set; }
    }
}
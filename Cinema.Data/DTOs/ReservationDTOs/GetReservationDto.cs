using Cinema.Data.DTOs.ReservedSeatDTOs;

namespace Cinema.Data.DTOs.ReservationDTOs
{
    public class GetReservationDto
    {
        public Guid Id { get; set; }
        public bool Reserved { get; set; }
        public Guid UserId { get; set; }
        public bool IsPaid { get; set; }

        public List<GetReservedSeatDto> ReservedSeats { get; set; } = null!;
    }
}
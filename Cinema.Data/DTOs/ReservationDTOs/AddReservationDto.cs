using Cinema.Data.DTOs.ReservedSeatDTOs;
using Cinema.Data.DTOs.UserDTOs;

namespace Cinema.Data.DTOs.ReservationDTOs
{
    public class AddReservationDto
    {
        public Guid UserId { get; set; }
        public bool IsPaid { get; set; }

        public List<AddReservedSeatDto> ReservedSeats { get; set; } = null!;
    }
}
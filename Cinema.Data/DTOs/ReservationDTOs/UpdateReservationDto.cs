using Cinema.Data.DTOs.ReservedSeatDTOs;
using Cinema.Data.DTOs.UserDTOs;

namespace Cinema.Data.DTOs.ReservationDTOs
{
    public class UpdateReservationDto
    {
        public Guid Id { get; set; }
        public bool Reserved { get; set; }
        public Guid UserId { get; set; }
        public bool IsPaid { get; set; }

        public ICollection<AddReservedSeatDto> ReservedSeats { get; set; } = null!;
        public AddUserDto User { get; set; } = null!;
    }
}
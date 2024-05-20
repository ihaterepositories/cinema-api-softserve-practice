using Cinema.Data.DTOs.ReservedSeatDTOs;
using Cinema.Data.DTOs.UserDTOs;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Data.DTOs.ReservationDTOs
{
    public class AddReservationDto
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public bool IsPaid { get; set; }

        public List<AddReservedSeatDto> ReservedSeats { get; set; } = null!;
    }
}
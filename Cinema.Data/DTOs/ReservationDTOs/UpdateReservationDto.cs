using Cinema.Data.DTOs.ReservedSeatDTOs;
using Cinema.Data.DTOs.UserDTOs;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Data.DTOs.ReservationDTOs
{
    public class UpdateReservationDto
    {
        public Guid Id { get; set; }
        [Required]
        public bool Reserved { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public bool IsPaid { get; set; }

        public List<AddReservedSeatDto> ReservedSeats { get; set; } = null!;
    }
}
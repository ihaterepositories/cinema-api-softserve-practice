using System.ComponentModel.DataAnnotations;

namespace Cinema.Data.DTOs.ReservedSeatDTOs
{
    public class AddReservedSeatDto
    {
        [Required]
        public Guid ReservationId { get; set; }
        [Required]
        public Guid SeatId { get; set; }
        [Required]
        public Guid ScreeningId { get; set; }
    }
}
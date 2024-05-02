using Cinema.Data.DTOs.ScreeningDTOs;
using Cinema.Data.DTOs.SeatDTOs;

namespace Cinema.Data.DTOs.ReservedSeatDTOs
{
    public class GetReservedSeatDto
    {
        public Guid Id { get; set; }
        public GetSeatDto Seat { get; set; } = null!;
        public GetScreeningDto Screening { get; set; } = null!;
    }
}
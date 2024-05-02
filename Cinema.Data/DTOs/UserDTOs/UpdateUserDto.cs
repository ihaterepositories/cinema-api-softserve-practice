using Cinema.Data.DTOs.ReservationDTOs;

namespace Cinema.Data.DTOs.UserDTOs
{
    public class UpdateUserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public List<UpdateReservationDto> Reservations { get; } = null!;
    }
}
using Cinema.Data.DTOs.MovieDTOs;
using Cinema.Data.DTOs.RoomsDTOs;

namespace Cinema.Data.DTOs.ScreeningDTOs
{
    public class GetScreeningDto
    {
        public Guid Id { get; set; }
        public GetMovieDto Movie { get; set; } = null!;
        public GetRoomDto Room { get; set; } = null!;
        public DateTime StartDateTime { get; set; }
        public double Price { get; set; }
    }
}
namespace Cinema.Data.DTOs.ReservedSeatDTOs;

public class UpdateReservedSeatDto
{
    public Guid Id { get; set; }
    public Guid ReservationId { get; set; }
    public bool IsReserved {  get; set; }
}
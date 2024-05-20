using System.ComponentModel.DataAnnotations;

namespace Cinema.Data.DTOs.ReservedSeatDTOs;

public class UpdateReservedSeatDto
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public Guid ReservationId { get; set; }
    [Required]
    public bool IsReserved {  get; set; }
}
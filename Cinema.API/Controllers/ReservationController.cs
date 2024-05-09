using Cinema.BLL.Services.Interfaces;
using Cinema.Data.DTOs.ReservationDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetReservations()
        {

            var response = await _reservationService.GetAsync();
            if (response is null)
                return NotFound();
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationById(Guid id)
        {
            var response = await _reservationService.GetByIdAsync(id);
            if (response is null)
                return NotFound();
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> PostReservation(AddReservationDto Reservation)
        {
            var response = await _reservationService.InsertAsync(Reservation);
            if (response is null)
                return NotFound();
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateReservation(UpdateReservationDto Reservation)
        {
            var response = await _reservationService.UpdateAsync(Reservation);
            if (response is null)
                return NotFound();
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(Guid id)
        {
            var response = await _reservationService.DeleteAsync(id);
            if (response is null)
                return NotFound();
            return Ok(response);
        }
    }
}
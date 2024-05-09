using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.BLL.Services.Interfaces;
using Cinema.Data.DTOs.SeatDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeatController : ControllerBase
    {
        private readonly ISeatService _seatService;
        public SeatController(ISeatService seatService)
        {
            _seatService = seatService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSeats()
        {

            var response = await _seatService.GetAsync();

            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeatById(Guid id)
        {
            var response = await _seatService.GetByIdAsync(id);
            if (response is null)
                return NotFound();
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> PostSeat(AddSeatDto Seat)
        {
            var response = await _seatService.InsertAsync(Seat);
            if (response is null || response.Data?.Count() == 0)
                return NotFound(response);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSeat(UpdateSeatDto Seat)
        {
            var response = await _seatService.UpdateAsync(Seat);
            if (response is null || response.Data?.Count() == 0)
                return NotFound(response);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeat(Guid id)
        {
            var response = await _seatService.DeleteAsync(id);
            if (response is null || response.Data?.Count() == 0)
                return NotFound(response);
            return Ok(response);
        }
    }
}
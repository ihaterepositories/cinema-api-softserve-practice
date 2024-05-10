using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.BLL.Services.Interfaces;
using Cinema.Data.DTOs.ScreeningDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScreeningController : ControllerBase
    {
        private readonly IScreeningService _screeningService;
        public ScreeningController(IScreeningService screeningService)
        {
            _screeningService = screeningService;
        }

        [HttpGet]
        public async Task<IActionResult> GetScreenings()
        {

            var response = await _screeningService.GetAsync();

            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetScreeningById(Guid id)
        {
            var response = await _screeningService.GetByIdAsync(id);
            if (response is null)
                return NotFound();
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> PostScreening(AddScreeningDto movie)
        {
            var response = await _screeningService.InsertAsync(movie);
            if (response is null)
                return NotFound();
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateScreening(UpdateScreeningDto movie)
        {
            var response = await _screeningService.UpdateAsync(movie);
            if (response is null)
                return NotFound();
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScreening(Guid id)
        {
            var response = await _screeningService.DeleteAsync(id);
            if (response is null)
                return NotFound();
            return Ok(response);
        }
    }
}
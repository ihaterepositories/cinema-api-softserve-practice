using Cinema.BLL.Services.Interfaces;
using Cinema.Data.DTOs.ActorDTOs;
using Cinema.Data.DTOs.MovieDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {

            var response = await _movieService.GetAsync();
            if (response is null)
                return NotFound();
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(Guid id)
        {
            var response = await _movieService.GetByIdAsync(id);
            if (response is null)
                return NotFound();
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> PostMovie(AddMovieDto movie)
        {
            var response = await _movieService.InsertAsync(movie);
            if (response is null)
                return NotFound();
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMovie(UpdateMovieDto movie)
        {
            var response = await _movieService.UpdateAsync(movie);
            if (response is null)
                return NotFound();
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(Guid id)
        {
            var response = await _movieService.DeleteAsync(id);
            if (response is null)
                return NotFound();
            return Ok(response);
        }
    }
}
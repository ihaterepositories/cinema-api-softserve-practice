using Cinema.BLL.Services.Interfaces;
using Cinema.Data.DTOs.GenreDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<IActionResult> GetGenres()
        {

            var response = await _genreService.GetAsync();

            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenreById(Guid id)
        {
            var response = await _genreService.GetByIdAsync(id);
            if (response is null)
                return NotFound();
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> PostMovie(AddGenreDto movie)
        {
            var response = await _genreService.InsertAsync(movie);
            if (response is null)
                return NotFound();
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMovie(UpdateGenreDto movie)
        {
            var response = await _genreService.UpdateAsync(movie);
            if (response is null)
                return NotFound();
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(Guid id)
        {
            var response = await _genreService.DeleteAsync(id);
            if (response is null)
                return NotFound();
            return Ok(response);
        }
    }
}
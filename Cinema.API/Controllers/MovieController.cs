using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.BLL.Services.Interfaces;
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
        public async Task<IActionResult> GetMoviesFullInformation()
        {
            var response = await _movieService.GetAsync();

            if (response.Count() == 0)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(Guid id)
        {
            var response = await _movieService.GetByIdAsync(id);

            if (response is null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        // [HttpPost]
        // public async Task<IActionResult> PostMovie(AddMovieDto movie)
        // {
        //     await _movieService.InsertAsync(movie);

        //     return Ok();
        // }
    }
}
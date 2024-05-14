using System.Net;
using Cinema.BLL.Services.Interfaces;
using Cinema.Data.DTOs.MovieDTOs;
using Cinema.Data.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private IMovieService Service { get; }

        public MovieController(IMovieService movieService)
        {
            Service = movieService;
        }
        
        /// <summary>
        /// Retrieves a paginated list of movies.
        /// </summary>
        /// <param name="take">The number of movies to take.</param>
        /// <param name="skip">The number of movies to skip.</param>
        /// <returns>A <see cref="Task<IActionResult>"/> representing the result of the asynchronous operation.</returns>
        /// <response code="200">Returns the requested list of movies.</response>
        /// <response code="404">If no movies are found.</response>
        /// <response code="500">If there was an internal server error.</response>
        [HttpGet("GetTakeSkip")]
        [ProducesResponseType(typeof(BaseResponse<List<GetMovieDto>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<List<GetMovieDto>>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(BaseResponse<List<GetMovieDto>>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetTakeSkip(int take, int skip)
        {
            var response = await Service.GetTakeSkip(take, skip);
            
            return response.StatusCode switch
            {
                Data.Responses.Enums.StatusCode.Ok => Ok(response),
                Data.Responses.Enums.StatusCode.NotFound => NotFound(response),
                Data.Responses.Enums.StatusCode.BadRequest => BadRequest(response),
                Data.Responses.Enums.StatusCode.InternalServerError => StatusCode(500, response),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        
        /// <summary>
        /// Retrieves a paginated list of movies.
        /// </summary>
        /// <param name="take">The number of movies to take.</param>
        /// <param name="skip">The number of movies to skip.</param>
        /// <param name="sortBy">The property by which to sort the movies. (title, releaseDate, rating)</param>
        /// <returns>A <see cref="Task<IActionResult>"/> representing the result of the asynchronous operation.</returns>
        /// <response code="200">Returns the requested list of movies.</response>
        /// <response code="404">If no movies are found.</response>
        /// <response code="500">If there was an internal server error.</response>
        [HttpGet("GetTakeSkipSortBy")]
        [ProducesResponseType(typeof(BaseResponse<List<GetMovieDto>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<List<GetMovieDto>>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(BaseResponse<List<GetMovieDto>>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetTakeSkipSortBy(int take, int skip, string sortBy)
        {
            var response = await Service.GetTakeSkipSortByAsync(take, skip, sortBy);
            
            return response.StatusCode switch
            {
                Data.Responses.Enums.StatusCode.Ok => Ok(response),
                Data.Responses.Enums.StatusCode.NotFound => NotFound(response),
                Data.Responses.Enums.StatusCode.BadRequest => BadRequest(response),
                Data.Responses.Enums.StatusCode.InternalServerError => StatusCode(500, response),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        [HttpGet("GetAllMovies")]
        [ProducesResponseType(typeof(BaseResponse<List<GetMovieDto>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<List<GetMovieDto>>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(BaseResponse<List<GetMovieDto>>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetMovies()
        {
            var response = await Service.GetAsync();
            
            return response.StatusCode switch
            {
                Data.Responses.Enums.StatusCode.Ok => Ok(response),
                Data.Responses.Enums.StatusCode.NotFound => NotFound(response),
                Data.Responses.Enums.StatusCode.BadRequest => BadRequest(response),
                Data.Responses.Enums.StatusCode.InternalServerError => StatusCode(500, response),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        
        [HttpGet]
        [Route("[action]/{id}", Name = "GetMovieById")]
        [ProducesResponseType(typeof(BaseResponse<GetMovieDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<GetMovieDto>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<GetMovieDto>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(BaseResponse<GetMovieDto>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetMovieById(Guid id)
        {
            var response = await Service.GetByIdAsync(id);
            
            return response.StatusCode switch
            {
                Data.Responses.Enums.StatusCode.Ok => Ok(response),
                Data.Responses.Enums.StatusCode.NotFound => NotFound(response),
                Data.Responses.Enums.StatusCode.BadRequest => BadRequest(response),
                Data.Responses.Enums.StatusCode.InternalServerError => StatusCode(500, response),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        
        [HttpPost("PostMovie")]
        [ProducesResponseType(typeof(BaseResponse<AddMovieDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<AddMovieDto>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<AddMovieDto>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PostMovie(AddMovieDto movie)
        {
            var response = await Service.InsertAsync(movie);
            
            return response.StatusCode switch
            {
                Data.Responses.Enums.StatusCode.Ok => Ok(response),
                Data.Responses.Enums.StatusCode.NotFound => NotFound(response),
                Data.Responses.Enums.StatusCode.BadRequest => BadRequest(response),
                Data.Responses.Enums.StatusCode.InternalServerError => StatusCode(500, response),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        
        [HttpPut("UpdateMovie")]
        [ProducesResponseType(typeof(BaseResponse<UpdateMovieDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<UpdateMovieDto>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<UpdateMovieDto>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateMovie(UpdateMovieDto movie)
        {
            var response = await Service.UpdateAsync(movie);
            
            return response.StatusCode switch
            {
                Data.Responses.Enums.StatusCode.Ok => Ok(response),
                Data.Responses.Enums.StatusCode.NotFound => NotFound(response),
                Data.Responses.Enums.StatusCode.BadRequest => BadRequest(response),
                Data.Responses.Enums.StatusCode.InternalServerError => StatusCode(500, response),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        [HttpDelete]
        [Route("[action]/{id}", Name = "DeleteMovie")]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteMovie(Guid id)
        {
            var response = await Service.DeleteAsync(id);
            
            return response.StatusCode switch
            {
                Data.Responses.Enums.StatusCode.Ok => Ok(response),
                Data.Responses.Enums.StatusCode.NotFound => NotFound(response),
                Data.Responses.Enums.StatusCode.BadRequest => BadRequest(response),
                Data.Responses.Enums.StatusCode.InternalServerError => StatusCode(500, response),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
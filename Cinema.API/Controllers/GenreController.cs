using System.Net;
using Cinema.BLL.Services.Interfaces;
using Cinema.Data.DTOs.GenreDTOs;
using Cinema.Data.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {
        private IGenreService Service { get; }

        public GenreController(
            IGenreService genreService
                )
        {
            Service = genreService;
        }

        [HttpGet("GetAllGenres")]
        [ProducesResponseType(typeof(BaseResponse<List<GetGenreDto>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<List<GetGenreDto>>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(BaseResponse<List<GetGenreDto>>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetGenres()
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
        [Route("[action]/{id}", Name = "GetGenreById")]
        [ProducesResponseType(typeof(BaseResponse<GetGenreDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<GetGenreDto>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<GetGenreDto>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(BaseResponse<GetGenreDto>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetGenreById(Guid id)
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
        
        [HttpPost("PostGenre")]
        [ProducesResponseType(typeof(BaseResponse<AddGenreDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<AddGenreDto>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<AddGenreDto>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PostGenre(AddGenreDto genre)
        {
            var response = await Service.InsertAsync(genre);
            
            return response.StatusCode switch
            {
                Data.Responses.Enums.StatusCode.Ok => Ok(response),
                Data.Responses.Enums.StatusCode.NotFound => NotFound(response),
                Data.Responses.Enums.StatusCode.BadRequest => BadRequest(response),
                Data.Responses.Enums.StatusCode.InternalServerError => StatusCode(500, response),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        
        [HttpPut("UpdateGenre")]
        [ProducesResponseType(typeof(BaseResponse<UpdateGenreDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<UpdateGenreDto>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<UpdateGenreDto>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateGenre(UpdateGenreDto genre)
        {
            var response = await Service.UpdateAsync(genre);
            
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
        [Route("[action]/{id}", Name = "DeleteGenreById")]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteGenre(Guid id)
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
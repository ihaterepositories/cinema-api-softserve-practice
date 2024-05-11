using System.Net;
using Cinema.BLL.Services.Interfaces;
using Cinema.Data.DTOs.GenreDTOs;
using Cinema.Data.DTOs.ScreeningDTOs;
using Cinema.Data.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScreeningController : ControllerBase
    {
        private IScreeningService Service { get; }

        public ScreeningController(IScreeningService screeningService)
        {
            Service = screeningService;
        }

        [HttpGet("GetActualScreenings")]
        [ProducesResponseType(typeof(BaseResponse<List<GetScreeningDto>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<List<GetScreeningDto>>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(BaseResponse<List<GetScreeningDto>>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetActualScreenings()
        {
            var response = await Service.GetActualAsync();

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
        [Route("[action]actual/movieName/{movieName}", Name = "GetActualScreeningsByMovieName")]
        [ProducesResponseType(typeof(BaseResponse<List<GetScreeningDto>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<List<GetScreeningDto>>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(BaseResponse<List<GetScreeningDto>>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetActualScreeningsByMovieName(string movieName)
        {
            var response = await Service.GetActualByMovieNameAsync(movieName);
            
            return response.StatusCode switch
            {
                Data.Responses.Enums.StatusCode.Ok => Ok(response),
                Data.Responses.Enums.StatusCode.NotFound => NotFound(response),
                Data.Responses.Enums.StatusCode.BadRequest => BadRequest(response),
                Data.Responses.Enums.StatusCode.InternalServerError => StatusCode(500, response),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        
        [HttpGet("GetAllScreenings")]
        [ProducesResponseType(typeof(BaseResponse<List<GetScreeningDto>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<List<GetScreeningDto>>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(BaseResponse<List<GetScreeningDto>>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetScreenings()
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
        [Route ("[action]/{id}", Name = "GetScreeningById")]
        [ProducesResponseType(typeof(BaseResponse<GetScreeningDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<GetScreeningDto>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<GetScreeningDto>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(BaseResponse<GetScreeningDto>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetScreeningById(Guid id)
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
        
        [HttpPost("PostScreening")]
        [ProducesResponseType(typeof(BaseResponse<AddScreeningDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<AddScreeningDto>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<AddScreeningDto>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PostScreening(AddScreeningDto screening)
        {
            var response = await Service.InsertAsync(screening);
            
            return response.StatusCode switch
            {
                Data.Responses.Enums.StatusCode.Ok => Ok(response),
                Data.Responses.Enums.StatusCode.NotFound => NotFound(response),
                Data.Responses.Enums.StatusCode.BadRequest => BadRequest(response),
                Data.Responses.Enums.StatusCode.InternalServerError => StatusCode(500, response),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        
        [HttpPut("UpdateScreening")]
        [ProducesResponseType(typeof(BaseResponse<UpdateScreeningDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<UpdateScreeningDto>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<UpdateScreeningDto>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateScreening(UpdateScreeningDto screening)
        {
            var response = await Service.UpdateAsync(screening);
            
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
        [Route("[action]/{id}", Name = "DeleteScreening")]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteScreening(Guid id)
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
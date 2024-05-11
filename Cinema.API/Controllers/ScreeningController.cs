using Cinema.BLL.Services.Interfaces;
using Cinema.Data.DTOs.ScreeningDTOs;
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

        [HttpGet("actual")]
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
        
        [HttpGet("actual/movieName/{movieName}")]
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

        [HttpGet("actual/screeningdate/{screeningdate}")]//format YYYY-MM-DD
        public async Task<IActionResult> GetActualScreeningsByScreeningDate(string screeningdate)
        {
            var strings= Array.ConvertAll(screeningdate.Split('-'), int.Parse);
            var response = await Service.GetActualByDateAsync(new DateOnly(strings[0], strings[1], strings[2]));

            return response.StatusCode switch
            {
                Data.Responses.Enums.StatusCode.Ok => Ok(response),
                Data.Responses.Enums.StatusCode.NotFound => NotFound(response),
                Data.Responses.Enums.StatusCode.BadRequest => BadRequest(response),
                Data.Responses.Enums.StatusCode.InternalServerError => StatusCode(500, response),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        [HttpGet("actual/screeningduration/{minduration}/{maxduration}")]//format HH:mm:ss
        public async Task<IActionResult> GetActualScreeningsByDuration(string minduration,string maxduration)
        {
            var response = await Service.GetActualByDurationAsync(minduration,maxduration);

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
        
        [HttpGet("{id}")]
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
        
        [HttpPost]
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
        
        [HttpPut]
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

        [HttpDelete("{id}")]
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
using System.Net;
using Cinema.BLL.Services.Interfaces;
using Cinema.Data.DTOs.ScreeningDTOs;
using Cinema.Data.DTOs.SeatDTOs;
using Cinema.Data.DTOs.StatsDTOs;
using Cinema.Data.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatsController : ControllerBase
    {
        private IStatsService Service { get; }

        public StatsController(IStatsService service)
        {
            Service = service;
        }
        
        [HttpGet]
        [Route("[action]/{id}", Name = "GetMovieSellsStatsById")]
        [ProducesResponseType(typeof(BaseResponse<GetMovieSellsStatsDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<GetMovieSellsStatsDTO>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<GetMovieSellsStatsDTO>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(BaseResponse<GetMovieSellsStatsDTO>), (int)HttpStatusCode.InternalServerError)]
        [Authorize(Policy = "OnlyAdmin")]
        public async Task<IActionResult> GetMovieSellsStatsById(Guid id)
        {
            var response = await Service.GetMovieSellsStatsAsync(id);
            
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
        [Route("[action]/{screeningdate}", Name = "GetRevenueByDay")]//format YYYY-MM-DD
        [ProducesResponseType(typeof(BaseResponse<List<GetRevenueByDayDTO>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<List<GetRevenueByDayDTO>>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(BaseResponse<List<GetRevenueByDayDTO>>), (int)HttpStatusCode.InternalServerError)]
        [Authorize(Policy = "OnlyAdmin")]
        public async Task<IActionResult> GetRevenueByDay(string screeningdate)
        {
            var strings = Array.ConvertAll(screeningdate.Split('-'), int.Parse);
            var response = await Service.GetRevenueByDayAsync(new DateOnly(strings[0], strings[1], strings[2]));

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
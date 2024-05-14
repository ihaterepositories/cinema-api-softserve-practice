using System.Net;
using Cinema.BLL.Services.Interfaces;
using Cinema.Data.DTOs.ActorDTOs;
using Cinema.Data.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorController : ControllerBase
    {
        private IActorService Service { get; }

        public ActorController(IActorService actorService)
        {
            Service = actorService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(BaseResponse<List<GetActorDto>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<List<GetActorDto>>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(BaseResponse<List<GetActorDto>>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetActors()
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
        [Route("[action]/{id}", Name = "GetActorById")]
        [ProducesResponseType(typeof(BaseResponse<GetActorDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<GetActorDto>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<GetActorDto>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(BaseResponse<GetActorDto>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetActorById(Guid id)
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
        [ProducesResponseType(typeof(BaseResponse<AddActorDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<AddActorDto>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<AddActorDto>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PostActor(AddActorDto actor)
        {
            var response = await Service.InsertAsync(actor);

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
        [ProducesResponseType(typeof(BaseResponse<UpdateActorDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<UpdateActorDto>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<UpdateActorDto>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateActor(UpdateActorDto actor)
        {
            var response = await Service.UpdateAsync(actor);
            
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
        [Route("[action]/{id}", Name = "DeleteActorById")]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteActor(Guid id)
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
using Cinema.BLL.Services.Interfaces;
using Cinema.Data.DTOs.ActorDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;
        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetActors()
        {

            var response = await _actorService.GetAsync();

            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActorById(Guid id)
        {
            var response = await _actorService.GetByIdAsync(id);
            if (response is null)
                return NotFound();
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> PostActor(AddActorDto actor)
        {
            var response = await _actorService.InsertAsync(actor);
            if (response is null || response.Data?.Count() == 0)
                return NotFound(response);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateActor(UpdateActorDto actor)
        {
            var response = await _actorService.UpdateAsync(actor);
            if (response is null || response.Data?.Count() == 0)
                return NotFound(response);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(Guid id)
        {
            var response = await _actorService.DeleteAsync(id);
            if (response is null || response.Data?.Count() == 0)
                return NotFound(response);
            return Ok(response);
        }
    }
}
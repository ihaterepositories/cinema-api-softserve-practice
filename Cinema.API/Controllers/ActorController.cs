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

            var result = await _actorService.GetAsync();

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActorById(Guid id)
        {
            var result = await _actorService.GetByIdAsync(id);
            if (result is null)
                return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> PostActor(AddActorDto actor)
        {
            await _actorService.InsertAsync(actor);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateActor(UpdateActorDto actor)
        {
            await _actorService.UpdateAsync(actor);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(Guid id)
        {
            await _actorService.DeleteAsync(id);
            return Ok();
        }
    }
}
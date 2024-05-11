using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Cinema.BLL.Services.Interfaces;
using Cinema.Data.DTOs.ActorDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cinema.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;
        private readonly ILogger<ActorController> _logger;

        public ActorController(
            IActorService actorService,
            ILogger<ActorController> logger
        )
        {
            _actorService = actorService;
            _logger = logger;
        }

        [HttpGet("GetAllActors")]
        [ProducesResponseType(typeof(List<GetActorDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetActors()
        {
            try
            {
                var result = await _actorService.GetAsync();
                if (result == null)
                {
                    _logger.LogWarning("No actors found");
                    return NotFound();
                }

                _logger.LogInformation("Actors retrieved successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving actors");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving actors");
            }
        }

        [HttpGet]
        [Route("[action]/{id}", Name = "GetActorById")]
        [ProducesResponseType(typeof(GetActorDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetActorById(Guid id)
        {
            try
            {
                var result = await _actorService.GetByIdAsync(id);
                if (result == null)
                {
                    _logger.LogWarning($"Actor with id {id} not found");
                    return NotFound();
                }

                _logger.LogInformation($"Actor with id {id} retrieved successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving actor with id {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while retrieving actor with id {id}");
            }
        }

        [HttpPost("PostActor")]
        [ProducesResponseType(typeof(AddActorDto), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PostActor(AddActorDto actor)
        {
            try
            {
                await _actorService.InsertAsync(actor);

                _logger.LogInformation($"Actor {actor.FullName} added successfully");
                return CreatedAtAction(nameof(GetActorById),  actor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while adding actor {actor.FullName}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding actor");
            }
        }

        [HttpPut("UpdateActor")]
        [ProducesResponseType(typeof(UpdateActorDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateActor(UpdateActorDto actor)
        {
            try
            {
                await _actorService.UpdateAsync(actor);
                return Ok(actor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the actor.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the actor.");
            }
        }

        [HttpDelete]
        [Route ("[action]/{id}", Name="DeleteActor")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteActor(Guid id)
        {
            try
            {
                await _actorService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the actor.");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "An error occurred while deleting the actor.");
            }
        }
    }
}

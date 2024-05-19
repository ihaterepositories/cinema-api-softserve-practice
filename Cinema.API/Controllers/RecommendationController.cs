using Cinema.BLL.Services;
using Cinema.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cinema.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "OnlyUser")]
public class RecommendationsController : ControllerBase
{
    private readonly IRecommendationService _recommendationService;

    public RecommendationsController(IRecommendationService recommendationService)
    {
        _recommendationService = recommendationService;
    }

    [HttpGet("user")]
    public async Task<IActionResult> GetUserRecommendations([FromQuery] int k = 5)
    {
        var userIdClaim = User.FindFirst("userId")?.Value;
        if (userIdClaim == null)
        {
            return Forbid();
        }

        var recommendations = await _recommendationService.GetRecommendationsForUserAsync(Guid.Parse(userIdClaim), k);
        if (recommendations == null || !recommendations.Any())
        {
            return NotFound("No recommendations found for the user.");
        }
        return Ok(recommendations);
    }
}

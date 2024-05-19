using Cinema.BLL.Services;
using Cinema.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetUserRecommendations(Guid userId, [FromQuery] int k = 5)
    {
        var recommendations = await _recommendationService.GetRecommendationsForUserAsync(userId, k);
        if (recommendations == null || !recommendations.Any())
        {
            return NotFound("No recommendations found for the user.");
        }
        return Ok(recommendations);
    }
}

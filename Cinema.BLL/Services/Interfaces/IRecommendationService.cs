using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Data.DTOs.MovieDTOs;
using Cinema.Data.Models;

namespace Cinema.BLL.Services.Interfaces;

public interface IRecommendationService
{
    Task<List<GetMovieDto>> GetRecommendationsForUserAsync(Guid userId, int k = 5);
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cinema.BLL.Services.Interfaces;
using Cinema.DAL.Infrastructure.Interfaces;
using Cinema.DAL.Repositories;
using Cinema.DAL.Repositories.Interfaces;
using Cinema.Data.DTOs.MovieDTOs;
using Cinema.Data.Models;

namespace Cinema.BLL.Services;

public class RecommendationService : IRecommendationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private IMovieRepository MovieRepository => _unitOfWork.MovieRepository;

    public RecommendationService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetMovieDto>> GetRecommendationsForUserAsync(Guid userId, int k = 5)
    {
        var userWatchedMovies = await MovieRepository.GetUserWatchedMoviesAsync(userId);
        var allMovies = await MovieRepository.GetAsync();
        var recommendedMovies = new List<Movie>();

        foreach (var watchedMovie in userWatchedMovies)
        {
            var neighbors = GetKNearestNeighbors(watchedMovie, allMovies, k);
            recommendedMovies.AddRange(neighbors);
        }

        var distinctRecommendedMovies = recommendedMovies.Distinct().ToList();
        return _mapper.Map<List<GetMovieDto>>(distinctRecommendedMovies);
    }

    private List<Movie> GetKNearestNeighbors(Movie watchedMovie, List<Movie> allMovies, int k)
    {
        var movieSimilarities = new List<Tuple<Movie, double>>();

        foreach (var movie in allMovies)
        {
            if (movie.Id == watchedMovie.Id) continue;
            double similarity = CalculateSimilarity(watchedMovie, movie);
            movieSimilarities.Add(new Tuple<Movie, double>(movie, similarity));
        }

        return movieSimilarities.OrderByDescending(ms => ms.Item2).Take(k).Select(ms => ms.Item1).ToList();
    }

    private double CalculateSimilarity(Movie movie1, Movie movie2)
    {
        int genreSimilarity = movie1.MovieGenres.Select(mg => mg.GenreId).Intersect(movie2.MovieGenres.Select(mg => mg.GenreId)).Count();
        int actorSimilarity = movie1.MovieActors.Select(ma => ma.ActorId).Intersect(movie2.MovieActors.Select(ma => ma.ActorId)).Count();
        
        return genreSimilarity + actorSimilarity;
    }
}

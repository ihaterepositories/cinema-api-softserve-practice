using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using Cinema.BLL.Helpers;
using Cinema.BLL.Services.Interfaces;
using Cinema.DAL.Infrastructure.Interfaces;
using Cinema.DAL.Repositories.Interfaces;
using Cinema.Data.DTOs.MovieDTOs;
using Cinema.Data.Models;
using Cinema.Data.Responses.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Cinema.BLL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseCreator _responseCreator;
        
        private readonly IDistributedCache _cache;
        private readonly int _cacheExpirationTime = 5;
        private readonly string _cacheKey = "movies";

        private IMovieRepository Repository => _unitOfWork.MovieRepository;

        public MovieService(IUnitOfWork unitOfWork, IMapper mapper, IDistributedCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _responseCreator = new ResponseCreator();
            _cache = cache;
        }
        
        public async Task<IBaseResponse<List<GetMovieDto>>> GetTakeSkip(int take, int skip)
        {
            try
            {
                var moviesFromDatabase = await Repository.GetTakeSkipAsync(take, skip);

                if (moviesFromDatabase.Count == 0)
                    return _responseCreator.CreateBaseNotFound<List<GetMovieDto>>("No movies found.");

                var moviesDto = _mapper.Map<List<GetMovieDto>>(moviesFromDatabase);

                return _responseCreator.CreateBaseOk(moviesDto, moviesDto.Count);
            }
            catch (Exception e)
            {
                return _responseCreator.CreateBaseServerError<List<GetMovieDto>>(e.Message);
            }
        }
        
        public async Task<IBaseResponse<List<GetMovieDto>>> GetTakeSkipSortByAsync(int take, int skip, string sortBy)
        {
            try
            {
                var moviesFromDatabase = await Repository.GetTakeSkipSortByAsync(take, skip, sortBy);

                if (moviesFromDatabase.Count == 0)
                    return _responseCreator.CreateBaseNotFound<List<GetMovieDto>>("No movies found.");

                var moviesDto = _mapper.Map<List<GetMovieDto>>(moviesFromDatabase);

                return _responseCreator.CreateBaseOk(moviesDto, moviesDto.Count);
            }
            catch (Exception e)
            {
                return _responseCreator.CreateBaseServerError<List<GetMovieDto>>(e.Message);
            }
        }
        
        // cache support enabled
        public async Task<IBaseResponse<List<GetMovieDto>>> GetNewMoviesAsync()
        {
            try
            {
                string responseDescription;
                string serializedMovies;
                List<Movie> movies;

                var cachedMovies = await _cache.GetAsync(_cacheKey);

                if (cachedMovies != null)
                {
                    serializedMovies = Encoding.UTF8.GetString(cachedMovies);
                    movies = JsonConvert.DeserializeObject<List<Movie>>(serializedMovies);
                    responseDescription = "Movies extracted from cache.";
                }
                else
                {
                    movies = await Repository.GetAsync();
                    
                    serializedMovies = JsonConvert.SerializeObject(movies, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                    
                    cachedMovies = Encoding.UTF8.GetBytes(serializedMovies);

                    await _cache.SetAsync(_cacheKey, cachedMovies, new DistributedCacheEntryOptions()
                        .SetAbsoluteExpiration(DateTime.Now.AddMinutes(_cacheExpirationTime)));

                    responseDescription = $"Movies extracted from database. Cached for {_cacheExpirationTime} minutes.";
                }

                if (movies.Count == 0)
                    return _responseCreator.CreateBaseNotFound<List<GetMovieDto>>("No movies found.");

                movies = movies
                    .Where(m => m.ReleaseDate.CompareTo(DateOnly.FromDateTime(DateTime.Now))!=-1).ToList();
                
                if (movies.Count == 0)
                    return _responseCreator.CreateBaseNotFound<List<GetMovieDto>>("No new movies found.");
                
                var moviesDto = _mapper.Map<List<GetMovieDto>>(movies);

                return _responseCreator.CreateBaseOk(moviesDto, moviesDto.Count, responseDescription);
            }
            catch (Exception e)
            {
                return _responseCreator.CreateBaseServerError<List<GetMovieDto>>(e.Message);
            }
        }

        // cache support enabled
        public async Task<IBaseResponse<List<GetMovieDto>>> GetAsync()
        {
            try
            {
                string responseDescription;
                string serializedMovies;
                List<Movie> movies;

                var cachedMovies = await _cache.GetAsync(_cacheKey);

                if (cachedMovies != null)
                {
                    serializedMovies = Encoding.UTF8.GetString(cachedMovies);
                    movies = JsonConvert.DeserializeObject<List<Movie>>(serializedMovies);
                    responseDescription = "Movies extracted from cache.";
                }
                else
                {
                    movies = await Repository.GetAsync();
                    
                    serializedMovies = JsonConvert.SerializeObject(movies, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                    
                    cachedMovies = Encoding.UTF8.GetBytes(serializedMovies);

                    await _cache.SetAsync(_cacheKey, cachedMovies, new DistributedCacheEntryOptions()
                        .SetAbsoluteExpiration(DateTime.Now.AddMinutes(_cacheExpirationTime)));

                    responseDescription = $"Movies extracted from database. Cached for {_cacheExpirationTime} minutes.";
                }

                if (movies.Count == 0)
                    return _responseCreator.CreateBaseNotFound<List<GetMovieDto>>("No movies found.");

                var moviesDto = _mapper.Map<List<GetMovieDto>>(movies);

                return _responseCreator.CreateBaseOk(moviesDto, moviesDto.Count, responseDescription);
            }
            catch (Exception e)
            {
                return _responseCreator.CreateBaseServerError<List<GetMovieDto>>(e.Message);
            }
        }

        // cache support enabled
        public async Task<IBaseResponse<GetMovieDto>> GetByIdAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return _responseCreator.CreateBaseBadRequest<GetMovieDto>("Id is empty.");

                var movieCacheKey = await _cache.GetStringAsync(id.ToString());
                Movie movie;
                string responseDescription;

                if (movieCacheKey != null)
                {
                    movie = JsonSerializer.Deserialize<Movie>(movieCacheKey, new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve
                    });
                    responseDescription = "Movie extracted from cache.";
                }
                else
                {
                    movie = await Repository.GetByIdAsync(id);
                    movieCacheKey = JsonSerializer.Serialize(movie, new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve
                    });

                    await _cache.SetStringAsync(movie.Id.ToString(), movieCacheKey, new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_cacheExpirationTime)
                    });

                    responseDescription = $"Movie extracted from database. Cached for {_cacheExpirationTime} minutes.";
                }

                if (movie == null)
                    return _responseCreator.CreateBaseNotFound<GetMovieDto>($"Movie with id {id} not found.");

                var movieDto = _mapper.Map<GetMovieDto>(movie);

                return _responseCreator.CreateBaseOk(movieDto, 1, responseDescription);
            }
            catch (Exception e)
            {
                return _responseCreator.CreateBaseServerError<GetMovieDto>(e.Message);
            }
        }

        public async Task<IBaseResponse<string>> InsertAsync(AddMovieDto entity)
        {
            try
            {
                if (entity == null)
                    return _responseCreator.CreateBaseBadRequest<string>("Movie is empty.");

                await Repository.InsertAsync(_mapper.Map<Movie>(entity));
                await _unitOfWork.SaveChangesAsync();

                return _responseCreator.CreateBaseOk($"Movie added.", 1);
            }
            catch (Exception e)
            {
                return _responseCreator.CreateBaseServerError<string>(e.Message);
            }
        }

        public async Task<IBaseResponse<string>> UpdateAsync(UpdateMovieDto entity)
        {
            try
            {
                if (entity == null)
                    return _responseCreator.CreateBaseBadRequest<string>("Movie is empty.");

                var existingMovie = await Repository.GetByIdAsync(entity.Id);

                if (existingMovie == null)
                    return _responseCreator.CreateBaseNotFound<string>("Movie not found.");

                existingMovie.MovieActors.Clear();
                existingMovie.MovieGenres.Clear();

                // Додаємо нові актори
                foreach (var actorDto in entity.MovieActors)
                {
                    existingMovie.MovieActors.Add(new MovieActor { MovieId = entity.Id, ActorId = actorDto.ActorId });
                }
                // Додаємо нові жанри
                foreach (var genreDto in entity.MovieGenres)
                {
                    existingMovie.MovieGenres.Add(new MovieGenre { MovieId = entity.Id, GenreId = genreDto.GenreId });
                }

                var result = _mapper.Map(entity, existingMovie);
                await Repository.UpdateAsync(result);
                await _unitOfWork.SaveChangesAsync();

                return _responseCreator.CreateBaseOk("Movie updated.", 1);
            }
            catch (Exception e)
            {
                return _responseCreator.CreateBaseServerError<string>(e.Message);
            }
        }

        public async Task<IBaseResponse<string>> DeleteAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return _responseCreator.CreateBaseBadRequest<string>("Id is empty.");

                await Repository.DeleteAsync(id);
                await _unitOfWork.SaveChangesAsync();

                return _responseCreator.CreateBaseOk("Movie deleted.", 1);
            }
            catch (Exception e)
            {
                return _responseCreator.CreateBaseServerError<string>(e.Message);
            }
        }


    }
}
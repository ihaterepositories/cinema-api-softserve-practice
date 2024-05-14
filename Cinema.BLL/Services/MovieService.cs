using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cinema.BLL.Helpers;
using Cinema.BLL.Services.Interfaces;
using Cinema.DAL.Infrastructure.Interfaces;
using Cinema.DAL.Repositories.Interfaces;
using Cinema.Data.DTOs.MovieDTOs;
using Cinema.Data.Models;
using Cinema.Data.Responses;
using Cinema.Data.Responses.Interfaces;

namespace Cinema.BLL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseCreator _responseCreator;

        private IMovieRepository Repository => _unitOfWork.MovieRepository;

        public MovieService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _responseCreator = new ResponseCreator();
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
        
        public async Task<IBaseResponse<List<GetMovieDto>>> GetNewMoviesAsync()
        {
            try
            {
                var moviesFromDatabase = await Repository.GetAsync();

                if (moviesFromDatabase.Count == 0)
                    return _responseCreator.CreateBaseNotFound<List<GetMovieDto>>("No movies found.");

                moviesFromDatabase = moviesFromDatabase
                    .Where(m => m.ReleaseDate.CompareTo(DateOnly.FromDateTime(DateTime.Now))!=-1).ToList();

                var moviesDto = _mapper.Map<List<GetMovieDto>>(moviesFromDatabase);

                return _responseCreator.CreateBaseOk(moviesDto, moviesDto.Count);
            }
            catch (Exception e)
            {
                return _responseCreator.CreateBaseServerError<List<GetMovieDto>>(e.Message);
            }
        }

        public async Task<IBaseResponse<List<GetMovieDto>>> GetAsync()
        {
            try
            {
                var moviesFromDatabase = await Repository.GetAsync();

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

        public async Task<IBaseResponse<List<GetMovieDto>>> GetNewMoviesAsync()
        {
            try
            {
                var moviesFromDatabase = await Repository.GetAsync();

                if (moviesFromDatabase.Count == 0)
                    return _responseCreator.CreateBaseNotFound<List<GetMovieDto>>("No movies found.");

                moviesFromDatabase = moviesFromDatabase
                    .Where(m => m.ReleaseDate.CompareTo(DateOnly.FromDateTime(DateTime.Now))!=-1).ToList();

                var moviesDto = _mapper.Map<List<GetMovieDto>>(moviesFromDatabase);

                return _responseCreator.CreateBaseOk(moviesDto, moviesDto.Count);
            }
            catch (Exception e)
            {
                return _responseCreator.CreateBaseServerError<List<GetMovieDto>>(e.Message);
            }
        }

        public async Task<IBaseResponse<GetMovieDto>> GetByIdAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return _responseCreator.CreateBaseBadRequest<GetMovieDto>("Id is empty.");

                var movieDto = _mapper.Map<GetMovieDto>(await Repository.GetByIdAsync(id));

                if (movieDto == null)
                    return _responseCreator.CreateBaseNotFound<GetMovieDto>($"Movie with id {id} not found.");

                return _responseCreator.CreateBaseOk(movieDto, 1);
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
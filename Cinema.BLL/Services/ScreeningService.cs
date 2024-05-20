using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cinema.BLL.Helpers;
using Cinema.BLL.Services.Interfaces;
using Cinema.DAL.Infrastructure.Interfaces;
using Cinema.DAL.Repositories.Interfaces;
using Cinema.Data.DTOs.MovieDTOs;
using Cinema.Data.DTOs.RoomsDTOs;
using Cinema.Data.DTOs.ScreeningDTOs;
using Cinema.Data.Models;
using Cinema.Data.Responses.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Cinema.BLL.Services;

public class ScreeningService : IScreeningService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ResponseCreator _responseCreator;
    
    private readonly IDistributedCache _cache;
    private readonly int _cacheExpirationTime = 5;
    private readonly string _cacheKey = "screenings";

    private IScreeningRepository Repository => _unitOfWork.ScreeningRepository;

    public ScreeningService(IUnitOfWork unitOfWork, IMapper mapper, IDistributedCache cache)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _responseCreator = new ResponseCreator();
        _cache = cache;
    }

    // cache support enabled
    public async Task<IBaseResponse<List<GetScreeningDto>>> GetActualAsync()
    {
        try
        {
            string responseDescription;
            string serializedScreenings;
            List<Screening> screenings;
            
            var cachedScreenings = await _cache.GetAsync(_cacheKey);

            if (cachedScreenings != null)
            {
                serializedScreenings = Encoding.UTF8.GetString(cachedScreenings);
                screenings = JsonConvert.DeserializeObject<List<Screening>>(serializedScreenings);
                responseDescription = "Screenings extracted from cache.";
            }
            else
            {
                screenings = await Repository.GetAsync();
                
                serializedScreenings = JsonConvert.SerializeObject(screenings, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                    
                cachedScreenings = Encoding.UTF8.GetBytes(serializedScreenings);

                await _cache.SetAsync(_cacheKey, cachedScreenings, new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(_cacheExpirationTime)));

                responseDescription = $"Screenings extracted from database. Cached for {_cacheExpirationTime} minutes.";
            }

            if (screenings.Count == 0)
                return _responseCreator.CreateBaseNotFound<List<GetScreeningDto>>("No screenings found.");
            
            screenings = screenings
                .Where(s => s.StartDateTime > DateTime.Now)
                .OrderBy(s => s.StartDateTime)
                .ToList();
            
            if (screenings.Count == 0)
                return _responseCreator.CreateBaseNotFound<List<GetScreeningDto>>($"No actual screenings found.");
            
            foreach (var screening in screenings)
            {
                screening.Movie = await _unitOfWork.MovieRepository.GetByIdAsync(screening.MovieId);
                screening.Room = await _unitOfWork.RoomRepository.GetByIdAsync(screening.RoomId);
            }

            var screeningsDto = _mapper.Map<List<GetScreeningDto>>(screenings);

            return _responseCreator.CreateBaseOk(screeningsDto, screeningsDto.Count, responseDescription);
        }
        catch (Exception e)
        {
            return _responseCreator.CreateBaseServerError<List<GetScreeningDto>>(e.Message);
        }
    }
    
    // cache support enabled
    public async Task<IBaseResponse<List<GetScreeningDto>>> GetActualByMovieNameAsync(string movieName)
    {
        try
        {
            string responseDescription;
            string serializedScreenings;
            List<Screening> screenings;
            
            var cachedScreenings = await _cache.GetAsync(_cacheKey);

            if (cachedScreenings != null)
            {
                serializedScreenings = Encoding.UTF8.GetString(cachedScreenings);
                screenings = JsonConvert.DeserializeObject<List<Screening>>(serializedScreenings);
                responseDescription = "Screenings extracted from cache.";
            }
            else
            {
                screenings = await Repository.GetAsync();
                
                serializedScreenings = JsonConvert.SerializeObject(screenings, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                    
                cachedScreenings = Encoding.UTF8.GetBytes(serializedScreenings);

                await _cache.SetAsync(_cacheKey, cachedScreenings, new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(_cacheExpirationTime)));

                responseDescription = $"Screenings extracted from database. Cached for {_cacheExpirationTime} minutes.";
            }

            if (screenings.Count == 0)
                return _responseCreator.CreateBaseNotFound<List<GetScreeningDto>>("No screenings found.");
            
            foreach (var screening in screenings)
            {
                screening.Movie = await _unitOfWork.MovieRepository.GetByIdAsync(screening.MovieId);
                screening.Room = await _unitOfWork.RoomRepository.GetByIdAsync(screening.RoomId);
            }
            
            screenings = screenings
                .FindAll(s => s.Movie.Name == movieName)
                .Where(s => s.StartDateTime > DateTime.Now)
                .OrderBy(s => s.StartDateTime)
                .ToList();
            
            if (screenings.Count == 0)
                return _responseCreator.CreateBaseNotFound<List<GetScreeningDto>>($"No actual screenings with {movieName} movie name found.");

            var screeningsDto = _mapper.Map<List<GetScreeningDto>>(screenings);

            return _responseCreator.CreateBaseOk(screeningsDto, screeningsDto.Count, responseDescription);
        }
        catch (Exception e)
        {
            return _responseCreator.CreateBaseServerError<List<GetScreeningDto>>(e.Message);
        }
    }

    // cache support enabled
    public async Task<IBaseResponse<List<GetScreeningDto>>> GetScreeningsByRoomId(Guid id)
    {
        try
        {
            string responseDescription;
            string serializedScreenings;
            List<Screening> screenings;
            
            var cachedScreenings = await _cache.GetAsync(_cacheKey);

            if (cachedScreenings != null)
            {
                serializedScreenings = Encoding.UTF8.GetString(cachedScreenings);
                screenings = JsonConvert.DeserializeObject<List<Screening>>(serializedScreenings);
                responseDescription = "Screenings extracted from cache.";
            }
            else
            {
                screenings = await Repository.GetAsync();
                
                serializedScreenings = JsonConvert.SerializeObject(screenings, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                    
                cachedScreenings = Encoding.UTF8.GetBytes(serializedScreenings);

                await _cache.SetAsync(_cacheKey, cachedScreenings, new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(_cacheExpirationTime)));

                responseDescription = $"Screenings extracted from database. Cached for {_cacheExpirationTime} minutes.";
            }

            if (screenings.Count == 0)
                return _responseCreator.CreateBaseNotFound<List<GetScreeningDto>>("No screenings found.");
            
            foreach (var screening in screenings)
            {
                screening.Movie = await _unitOfWork.MovieRepository.GetByIdAsync(screening.MovieId);
                screening.Room = await _unitOfWork.RoomRepository.GetByIdAsync(screening.RoomId);
            }
            
            screenings = screenings
                .FindAll(s => s.RoomId == id)
                .OrderBy(s => s.StartDateTime)
                .ToList();
            
            if (screenings.Count == 0)
                return _responseCreator.CreateBaseNotFound<List<GetScreeningDto>>($"No screenings in room with id {id} found.");

            var screeningsDto = _mapper.Map<List<GetScreeningDto>>(screenings);

            return _responseCreator.CreateBaseOk(screeningsDto, screeningsDto.Count, responseDescription);
        }
        catch (Exception e)
        {
            return _responseCreator.CreateBaseServerError<List<GetScreeningDto>>(e.Message);
        }
    }
   
    // cache support enabled
    public async Task<IBaseResponse<List<GetScreeningDto>>> GetAsync()
    {
        try
        {
            string responseDescription;
            string serializedScreenings;
            List<Screening> screenings;
            
            var cachedScreenings = await _cache.GetAsync(_cacheKey);

            if (cachedScreenings != null)
            {
                serializedScreenings = Encoding.UTF8.GetString(cachedScreenings);
                screenings = JsonConvert.DeserializeObject<List<Screening>>(serializedScreenings);
                responseDescription = "Screenings extracted from cache.";
            }
            else
            {
                screenings = await Repository.GetAsync();
                
                serializedScreenings = JsonConvert.SerializeObject(screenings, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                    
                cachedScreenings = Encoding.UTF8.GetBytes(serializedScreenings);

                await _cache.SetAsync(_cacheKey, cachedScreenings, new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(_cacheExpirationTime)));

                responseDescription = $"Screenings extracted from database. Cached for {_cacheExpirationTime} minutes.";
            }

            if (screenings.Count == 0)
                return _responseCreator.CreateBaseNotFound<List<GetScreeningDto>>("No screenings found.");
            
            foreach (var screening in screenings)
            {
                screening.Movie = await _unitOfWork.MovieRepository.GetByIdAsync(screening.MovieId);
                screening.Room = await _unitOfWork.RoomRepository.GetByIdAsync(screening.RoomId);
            }

            var screeningsDto = _mapper.Map<List<GetScreeningDto>>(screenings);

            return _responseCreator.CreateBaseOk(screeningsDto, screeningsDto.Count, responseDescription);
        }
        catch (Exception e)
        {
            return _responseCreator.CreateBaseServerError<List<GetScreeningDto>>(e.Message);
        }
    }

    public async Task<IBaseResponse<GetScreeningDto>> GetByIdAsync(Guid id)
    {
        try
        {
            if (id == Guid.Empty)
                return _responseCreator.CreateBaseBadRequest<GetScreeningDto>("Id is empty.");

            var screeningFromDatabase = await Repository.GetByIdAsync(id);

            if (screeningFromDatabase == null)
                return _responseCreator.CreateBaseNotFound<GetScreeningDto>($"Screening with id {id} not found.");

            // Retrieve associated movie and room entities
            var movie = await _unitOfWork.MovieRepository.GetByIdAsync(screeningFromDatabase.MovieId);
            var room = await _unitOfWork.RoomRepository.GetByIdAsync(screeningFromDatabase.RoomId);

            // Map entities to DTOs using AutoMapper
            var movieDto = _mapper.Map<GetMovieDto>(movie);
            var roomDto = _mapper.Map<GetRoomDto>(room);

            // Map the screening entity to GetScreeningDto
            var screeningDto = _mapper.Map<GetScreeningDto>(screeningFromDatabase);

            // Assign the mapped movie and room DTOs to the corresponding properties of the screening DTO
            screeningDto.Movie = movieDto;
            screeningDto.Room = roomDto;

            return _responseCreator.CreateBaseOk(screeningDto, 1);
        }
        catch (Exception e)
        {
            return _responseCreator.CreateBaseServerError<GetScreeningDto>(e.Message);
        }
    }
    
    // cache support enabled
    public async Task<IBaseResponse<List<GetScreeningDto>>> GetActualByDateAsync(DateOnly date)
    {
        try
        {
            string responseDescription;
            string serializedScreenings;
            List<Screening> screenings;
            
            var cachedScreenings = await _cache.GetAsync(_cacheKey);

            if (cachedScreenings != null)
            {
                serializedScreenings = Encoding.UTF8.GetString(cachedScreenings);
                screenings = JsonConvert.DeserializeObject<List<Screening>>(serializedScreenings);
                responseDescription = "Screenings extracted from cache.";
            }
            else
            {
                screenings = await Repository.GetAsync();
                
                serializedScreenings = JsonConvert.SerializeObject(screenings, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                    
                cachedScreenings = Encoding.UTF8.GetBytes(serializedScreenings);

                await _cache.SetAsync(_cacheKey, cachedScreenings, new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(_cacheExpirationTime)));

                responseDescription = $"Screenings extracted from database. Cached for {_cacheExpirationTime} minutes.";
            }
            
            if (screenings.Count == 0)
                return _responseCreator.CreateBaseNotFound<List<GetScreeningDto>>("No screenings found.");

            foreach (var screening in screenings)
            {
                screening.Movie = await _unitOfWork.MovieRepository.GetByIdAsync(screening.MovieId);
                screening.Room = await _unitOfWork.RoomRepository.GetByIdAsync(screening.RoomId);
            }

            screenings = screenings
                .Where(s => date.CompareTo(DateOnly.FromDateTime(s.StartDateTime))==0)
                .Where(s => s.StartDateTime > DateTime.Now)
                .OrderBy(s => s.StartDateTime)
                .ToList();
            
            if (screenings.Count == 0)
                return _responseCreator.CreateBaseNotFound<List<GetScreeningDto>>($"No actual screenings at {date} found.");

            var screeningsDto = _mapper.Map<List<GetScreeningDto>>(screenings);

            return _responseCreator.CreateBaseOk(screeningsDto, screeningsDto.Count, responseDescription);
        }
        catch (Exception e)
        {
            return _responseCreator.CreateBaseServerError<List<GetScreeningDto>>(e.Message);
        }
    }
    
    // cache support enabled
    public async Task<IBaseResponse<List<GetScreeningDto>>> GetActualByDurationAsync(string minDuration, string maxDuration)
    {
        try
        {
            string responseDescription;
            string serializedScreenings;
            List<Screening> screenings;
            
            var cachedScreenings = await _cache.GetAsync(_cacheKey);

            if (cachedScreenings != null)
            {
                serializedScreenings = Encoding.UTF8.GetString(cachedScreenings);
                screenings = JsonConvert.DeserializeObject<List<Screening>>(serializedScreenings);
                responseDescription = "Screenings extracted from cache.";
            }
            else
            {
                screenings = await Repository.GetAsync();
                
                serializedScreenings = JsonConvert.SerializeObject(screenings, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                    
                cachedScreenings = Encoding.UTF8.GetBytes(serializedScreenings);

                await _cache.SetAsync(_cacheKey, cachedScreenings, new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(_cacheExpirationTime)));

                responseDescription = $"Screenings extracted from database. Cached for {_cacheExpirationTime} minutes.";
            }
            
            if (screenings.Count == 0)
                return _responseCreator.CreateBaseNotFound<List<GetScreeningDto>>("No screenings found.");

            foreach (var screening in screenings)
            {
                screening.Movie = await _unitOfWork.MovieRepository.GetByIdAsync(screening.MovieId);
                screening.Room = await _unitOfWork.RoomRepository.GetByIdAsync(screening.RoomId);
            }

            screenings = screenings
                .Where(s=>s.Movie.Duration.CompareTo(TimeOnly.FromDateTime(DateTime.ParseExact(minDuration, "HH:mm:ss",CultureInfo.InvariantCulture))) !=-1)
                .Where(s => s.Movie.Duration.CompareTo(TimeOnly.FromDateTime(DateTime.ParseExact(maxDuration, "HH:mm:ss", CultureInfo.InvariantCulture))) != 1)
                .Where(s => s.StartDateTime > DateTime.Now)
                .OrderBy(s => s.StartDateTime)
                .ToList();
            
            if (screenings.Count == 0)
                return _responseCreator.CreateBaseNotFound<List<GetScreeningDto>>($"No actual screenings with inserted duration found.");

            var screeningsDto = _mapper.Map<List<GetScreeningDto>>(screenings);

            return _responseCreator.CreateBaseOk(screeningsDto, screeningsDto.Count, responseDescription);
        }
        catch (Exception e)
        {
            return _responseCreator.CreateBaseServerError<List<GetScreeningDto>>(e.Message);
        }
    }

    public async Task<IBaseResponse<string>> InsertAsync(AddScreeningDto entity)
    {
        try
        {
            if (entity == null)
                return _responseCreator.CreateBaseBadRequest<string>("Screening is empty.");

            await Repository.InsertAsync(_mapper.Map<Screening>(entity));
            await _unitOfWork.SaveChangesAsync();

            return _responseCreator.CreateBaseOk($"Screening added.", 1);
        }
        catch (Exception e)
        {
            return _responseCreator.CreateBaseServerError<string>(e.Message);
        }
    }

    public async Task<IBaseResponse<string>> UpdateAsync(UpdateScreeningDto entity)
    {
        try
        {
            if (entity == null)
                return _responseCreator.CreateBaseBadRequest<string>("Screening is empty.");

            await Repository.UpdateAsync(_mapper.Map<Screening>(entity));
            await _unitOfWork.SaveChangesAsync();

            return _responseCreator.CreateBaseOk("Screening updated.", 1);
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

            return _responseCreator.CreateBaseOk("Screening deleted.", 1);
        }
        catch (Exception e)
        {
            return _responseCreator.CreateBaseServerError<string>(e.Message);
        }
    }
}
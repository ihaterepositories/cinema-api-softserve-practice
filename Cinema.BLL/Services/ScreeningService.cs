using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

namespace Cinema.BLL.Services;

public class ScreeningService : IScreeningService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ResponseCreator _responseCreator;

    private IScreeningRepository Repository => _unitOfWork.ScreeningRepository;

    public ScreeningService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _responseCreator = new ResponseCreator();
    }

    public async Task<IBaseResponse<List<GetScreeningDto>>> GetActualAsync()
    {
        try
        {
            var screeningsFromDatabase = await Repository.GetAsync();
            
            screeningsFromDatabase = screeningsFromDatabase
                .Where(s => s.StartDateTime > DateTime.Now)
                .OrderBy(s => s.StartDateTime)
                .ToList();
            
            if (screeningsFromDatabase.Count == 0)
                return _responseCreator.CreateBaseNotFound<List<GetScreeningDto>>($"No actual screenings found.");
            
            foreach (var screening in screeningsFromDatabase)
            {
                screening.Movie = await _unitOfWork.MovieRepository.GetByIdAsync(screening.MovieId);
                screening.Room = await _unitOfWork.RoomRepository.GetByIdAsync(screening.RoomId);
            }

            var screeningsDto = _mapper.Map<List<GetScreeningDto>>(screeningsFromDatabase);

            return _responseCreator.CreateBaseOk(screeningsDto, screeningsDto.Count);
        }
        catch (Exception e)
        {
            return _responseCreator.CreateBaseServerError<List<GetScreeningDto>>(e.Message);
        }
    }
    
    public async Task<IBaseResponse<List<GetScreeningDto>>> GetActualByMovieNameAsync(string movieName)
    {
        try
        {
            var screeningsFromDatabase = await Repository.GetAsync();
            
            foreach (var screening in screeningsFromDatabase)
            {
                screening.Movie = await _unitOfWork.MovieRepository.GetByIdAsync(screening.MovieId);
                screening.Room = await _unitOfWork.RoomRepository.GetByIdAsync(screening.RoomId);
            }
            
            if (screeningsFromDatabase.Count == 0)
                return _responseCreator.CreateBaseNotFound<List<GetScreeningDto>>($"No actual screenings with {movieName} movie name found.");
            
            screeningsFromDatabase = screeningsFromDatabase
                .FindAll(s => s.Movie.Name == movieName)
                .Where(s => s.StartDateTime > DateTime.Now)
                .OrderBy(s => s.StartDateTime)
                .ToList();

            var screeningsDto = _mapper.Map<List<GetScreeningDto>>(screeningsFromDatabase);

            return _responseCreator.CreateBaseOk(screeningsDto, screeningsDto.Count);
        }
        catch (Exception e)
        {
            return _responseCreator.CreateBaseServerError<List<GetScreeningDto>>(e.Message);
        }
    }

<<<<<<< updating-controllers-and-adding-pagination
    public async Task<IBaseResponse<List<GetScreeningDto>>> GetScreeningsByRoomId(Guid id)
=======
    public async Task<IBaseResponse<List<GetScreeningDto>>> GetActualByDateAsync(DateOnly date)
>>>>>>> dev
    {
        try
        {
            var screeningsFromDatabase = await Repository.GetAsync();
<<<<<<< updating-controllers-and-adding-pagination
            
=======

>>>>>>> dev
            foreach (var screening in screeningsFromDatabase)
            {
                screening.Movie = await _unitOfWork.MovieRepository.GetByIdAsync(screening.MovieId);
                screening.Room = await _unitOfWork.RoomRepository.GetByIdAsync(screening.RoomId);
            }

            if (screeningsFromDatabase.Count == 0)
<<<<<<< updating-controllers-and-adding-pagination
                return _responseCreator.CreateBaseNotFound<List<GetScreeningDto>>($"No screenings found for room with id {id}.");
            
            screeningsFromDatabase = screeningsFromDatabase
                .FindAll(s => s.RoomId == id)
=======
                return _responseCreator.CreateBaseNotFound<List<GetScreeningDto>>($"No actual screenings at {date} found.");

            screeningsFromDatabase = screeningsFromDatabase
                .Where(s => date.CompareTo(DateOnly.FromDateTime(s.StartDateTime))==0)
                .Where(s => s.StartDateTime > DateTime.Now)
                .OrderBy(s => s.StartDateTime)
                .ToList();

            var screeningsDto = _mapper.Map<List<GetScreeningDto>>(screeningsFromDatabase);

            return _responseCreator.CreateBaseOk(screeningsDto, screeningsDto.Count);
        }
        catch (Exception e)
        {
            return _responseCreator.CreateBaseServerError<List<GetScreeningDto>>(e.Message);
        }
    }

    public async Task<IBaseResponse<List<GetScreeningDto>>> GetActualByDurationAsync(string minDuration, string maxDuration)
    {
        try
        {
            var screeningsFromDatabase = await Repository.GetAsync();

            foreach (var screening in screeningsFromDatabase)
            {
                screening.Movie = await _unitOfWork.MovieRepository.GetByIdAsync(screening.MovieId);
                screening.Room = await _unitOfWork.RoomRepository.GetByIdAsync(screening.RoomId);
            }

            if (screeningsFromDatabase.Count == 0)
                return _responseCreator.CreateBaseNotFound<List<GetScreeningDto>>($"No actual screenings with inserted duration found.");

            screeningsFromDatabase = screeningsFromDatabase
                .Where(s=>s.Movie.Duration.CompareTo(TimeOnly.FromDateTime(DateTime.ParseExact(minDuration, "HH:mm:ss",CultureInfo.InvariantCulture))) !=-1)
                .Where(s => s.Movie.Duration.CompareTo(TimeOnly.FromDateTime(DateTime.ParseExact(maxDuration, "HH:mm:ss", CultureInfo.InvariantCulture))) != 1)
                .Where(s => s.StartDateTime > DateTime.Now)
>>>>>>> dev
                .OrderBy(s => s.StartDateTime)
                .ToList();

            var screeningsDto = _mapper.Map<List<GetScreeningDto>>(screeningsFromDatabase);

            return _responseCreator.CreateBaseOk(screeningsDto, screeningsDto.Count);
        }
        catch (Exception e)
        {
            return _responseCreator.CreateBaseServerError<List<GetScreeningDto>>(e.Message);
        }
    }

    public async Task<IBaseResponse<List<GetScreeningDto>>> GetAsync()
    {
        try
        {
            var screeningsFromDatabase = await Repository.GetAsync();
            if (screeningsFromDatabase.Count == 0)
                return _responseCreator.CreateBaseNotFound<List<GetScreeningDto>>("No screenings found.");
            
            foreach (var screening in screeningsFromDatabase)
            {
                screening.Movie = await _unitOfWork.MovieRepository.GetByIdAsync(screening.MovieId);
                screening.Room = await _unitOfWork.RoomRepository.GetByIdAsync(screening.RoomId);
            }

            var screeningsDto = _mapper.Map<List<GetScreeningDto>>(screeningsFromDatabase);

            return _responseCreator.CreateBaseOk(screeningsDto, screeningsDto.Count);
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
    
    public async Task<IBaseResponse<List<GetScreeningDto>>> GetActualByDateAsync(DateOnly date)
    {
        try
        {
            var screeningsFromDatabase = await Repository.GetAsync();

            foreach (var screening in screeningsFromDatabase)
            {
                screening.Movie = await _unitOfWork.MovieRepository.GetByIdAsync(screening.MovieId);
                screening.Room = await _unitOfWork.RoomRepository.GetByIdAsync(screening.RoomId);
            }

            if (screeningsFromDatabase.Count == 0)
                return _responseCreator.CreateBaseNotFound<List<GetScreeningDto>>($"No actual screenings at {date} found.");

            screeningsFromDatabase = screeningsFromDatabase
                .Where(s => date.CompareTo(DateOnly.FromDateTime(s.StartDateTime))==0)
                .Where(s => s.StartDateTime > DateTime.Now)
                .OrderBy(s => s.StartDateTime)
                .ToList();

            var screeningsDto = _mapper.Map<List<GetScreeningDto>>(screeningsFromDatabase);

            return _responseCreator.CreateBaseOk(screeningsDto, screeningsDto.Count);
        }
        catch (Exception e)
        {
            return _responseCreator.CreateBaseServerError<List<GetScreeningDto>>(e.Message);
        }
    }
    
    public async Task<IBaseResponse<List<GetScreeningDto>>> GetActualByDurationAsync(string minDuration, string maxDuration)
    {
        try
        {
            var screeningsFromDatabase = await Repository.GetAsync();

            foreach (var screening in screeningsFromDatabase)
            {
                screening.Movie = await _unitOfWork.MovieRepository.GetByIdAsync(screening.MovieId);
                screening.Room = await _unitOfWork.RoomRepository.GetByIdAsync(screening.RoomId);
            }

            if (screeningsFromDatabase.Count == 0)
                return _responseCreator.CreateBaseNotFound<List<GetScreeningDto>>($"No actual screenings with inserted duration found.");

            screeningsFromDatabase = screeningsFromDatabase
                .Where(s=>s.Movie.Duration.CompareTo(TimeOnly.FromDateTime(DateTime.ParseExact(minDuration, "HH:mm:ss",CultureInfo.InvariantCulture))) !=-1)
                .Where(s => s.Movie.Duration.CompareTo(TimeOnly.FromDateTime(DateTime.ParseExact(maxDuration, "HH:mm:ss", CultureInfo.InvariantCulture))) != 1)
                .Where(s => s.StartDateTime > DateTime.Now)
                .OrderBy(s => s.StartDateTime)
                .ToList();

            var screeningsDto = _mapper.Map<List<GetScreeningDto>>(screeningsFromDatabase);

            return _responseCreator.CreateBaseOk(screeningsDto, screeningsDto.Count);
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
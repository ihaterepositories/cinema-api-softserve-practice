using AutoMapper;
using Cinema.BLL.Helpers;
using Cinema.BLL.Services.Interfaces;
using Cinema.DAL.Infrastructure.Interfaces;
using Cinema.DAL.Repositories.Interfaces;
using Cinema.Data.DTOs.MovieDTOs;
using Cinema.Data.DTOs.StatsDTOs;
using Cinema.Data.Models;
using Cinema.Data.Responses.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using Cinema.Data.DTOs.ScreeningDTOs;

namespace Cinema.BLL.Services
{
    public class StatsService : IStatsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseCreator _responseCreator;

        public StatsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _responseCreator = new ResponseCreator();
        }

        private IMovieRepository Repository => _unitOfWork.MovieRepository;
        public async Task<IBaseResponse<GetMovieSellsStatsDTO>> GetMovieSellsStatsAsync(Guid movieId)
        {
            try
            {
                var movieStatsDTO=new GetMovieSellsStatsDTO();

                if (movieId == Guid.Empty)
                    return _responseCreator.CreateBaseBadRequest<GetMovieSellsStatsDTO>("Id is empty.");
                
                var movie = await Repository.GetByIdAsync(movieId);

                if (movie == null)
                    return _responseCreator.CreateBaseNotFound<GetMovieSellsStatsDTO>($"Movie with id {movieId} not found.");

                movieStatsDTO.Movie= _mapper.Map<GetMovieDto>(movie);

                var screenings = await _unitOfWork.ScreeningRepository.GetAsync();
                screenings=screenings.Where(x=>x.MovieId == movieId).ToList();

                foreach (var screening in screenings)
                {
                    var screeningIncomeDTO=new ScreeningIncomeDTO();
                    screeningIncomeDTO.screening= _mapper.Map<GetScreeningDto>(screening);

                    var seatsReserved=await _unitOfWork.ReservedSeatRepository.GetAsync();
                    screeningIncomeDTO.Income=seatsReserved.Where(x=>x.ScreeningId==screening.Id).Count()*screening.Price;

                    movieStatsDTO.screeningIncome.Add(screeningIncomeDTO);
                }

                return _responseCreator.CreateBaseOk(movieStatsDTO, 1);
            }
            catch (Exception e)
            {
                return _responseCreator.CreateBaseServerError<GetMovieSellsStatsDTO>(e.Message);
            }
        }

        public async Task<IBaseResponse<List<GetRevenueByDayDTO>>> GetRevenueByDayAsync(DateOnly date)
        {
            try
            {
                var revenueByDayDTOs = new List<GetRevenueByDayDTO>();

                var screenings = await _unitOfWork.ScreeningRepository.GetAsync();

                screenings = screenings
                .Where(s => date.CompareTo(DateOnly.FromDateTime(s.StartDateTime)) == 0)
                .ToList();

                if (screenings == null)
                    return _responseCreator.CreateBaseNotFound<List<GetRevenueByDayDTO>>($"Screenings on {date} were not found!");

                foreach (var screening in screenings)
                {
                    screening.Movie = await _unitOfWork.MovieRepository.GetByIdAsync(screening.MovieId);
                    screening.Room = await _unitOfWork.RoomRepository.GetByIdAsync(screening.RoomId);
                }
                foreach (var screening in screenings)
                {
                    var getRevenueByDayDTO = new GetRevenueByDayDTO();
                    getRevenueByDayDTO.screening = _mapper.Map<GetScreeningDto>(screening); ;

                    var seatsReserved = await _unitOfWork.ReservedSeatRepository.GetAsync();
                    getRevenueByDayDTO.Revenue = seatsReserved.Where(x => x.ScreeningId == screening.Id).Count() * screening.Price;

                    revenueByDayDTOs.Add(getRevenueByDayDTO);
                }

                return _responseCreator.CreateBaseOk(revenueByDayDTOs, revenueByDayDTOs.Count);
            }
            catch (Exception e)
            {
                return _responseCreator.CreateBaseServerError<List<GetRevenueByDayDTO>>(e.Message);
            }
        }
    }
}

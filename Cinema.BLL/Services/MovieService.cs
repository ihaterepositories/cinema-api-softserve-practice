using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cinema.BLL.Services.Interfaces;
using Cinema.DAL.Infrastructure.Interfaces;
using Cinema.Data.DTOs.MovieDTOs;
using Cinema.Data.Models;

namespace Cinema.BLL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public MovieService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<GetMovieDto>> GetAsync()
        {
            var moviesFromDatabase = await _unitOfWork.MovieRepository.GetAsync();

            var moviesDto = _mapper.Map<List<GetMovieDto>>(moviesFromDatabase);
            return moviesDto;
        }

        public async Task<GetMovieDto> GetByIdAsync(Guid id)
        {
            var movieFromDatabase = await _unitOfWork.MovieRepository.GetByIdAsync(id);
            var movieDto = _mapper.Map<GetMovieDto>(movieFromDatabase);
            return movieDto;
        }
        public async Task DeleteAsync(Guid id)
        {
            await _unitOfWork.MovieRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task InsertAsync(AddMovieDto entity)
        {
            var movieToInsert = _mapper.Map<Movie>(entity);
            await _unitOfWork.MovieRepository.InsertAsync(movieToInsert);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateMovieDto entity)
        {
            var updatedMovie = _mapper.Map<Movie>(entity);
            await _unitOfWork.MovieRepository.UpdateAsync(updatedMovie);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
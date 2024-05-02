using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cinema.BLL.Helpers;
using Cinema.BLL.Services.Interfaces;
using Cinema.DAL.Infrastructure.Interfaces;
using Cinema.DAL.Repositories.Interfaces;
using Cinema.Data.DTOs.GenreDTOs;
using Cinema.Data.Models;
using Cinema.Data.Responses.Interfaces;

namespace Cinema.BLL.Services;

public class GenreService : IGenreService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ResponseCreator _responseCreator;
        
    private IGenreRepository Repository => _unitOfWork.GenreRepository;
        
    public GenreService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _responseCreator = new ResponseCreator();
    }
    
    public async Task<IBaseResponse<List<GetGenreDto>>> GetAsync()
    {
        try
        {
            var actorsFromDatabase = await Repository.GetAsync();
                
            if (actorsFromDatabase.Count == 0)
                return _responseCreator.CreateBaseNotFound<List<GetGenreDto>>("No genres found.");
                
            var genresDto = _mapper.Map<List<GetGenreDto>>(actorsFromDatabase);

            return _responseCreator.CreateBaseOk(genresDto, genresDto.Count);
        }
        catch (Exception e)
        {
            return _responseCreator.CreateBaseServerError<List<GetGenreDto>>(e.Message);
        }
    }

    public async Task<IBaseResponse<GetGenreDto>> GetByIdAsync(Guid id)
    {
        try
        {
            if (id == Guid.Empty)
                return _responseCreator.CreateBaseBadRequest<GetGenreDto>("Id is empty.");
                
            if (await Repository.ExistsAsync(id) == false)
                return _responseCreator.CreateBaseNotFound<GetGenreDto>($"Genre with id {id} not found.");
                
            var genreDto = _mapper.Map<GetGenreDto>(await Repository.GetByIdAsync(id));

            return _responseCreator.CreateBaseOk(genreDto, 1);
        }
        catch (Exception e)
        {
            return _responseCreator.CreateBaseServerError<GetGenreDto>(e.Message);
        }
    }

    public async Task<IBaseResponse<string>> InsertAsync(AddGenreDto entity)
    {
        try
        {
            if (entity == null)
                return _responseCreator.CreateBaseBadRequest<string>("Genre is empty.");
                
            await Repository.InsertAsync(_mapper.Map<Genre>(entity));
            await _unitOfWork.SaveChangesAsync();
                
            return _responseCreator.CreateBaseOk($"Genre added.", 1);
        }
        catch (Exception e)
        {
            return _responseCreator.CreateBaseServerError<string>(e.Message);
        }
    }

    public async Task<IBaseResponse<string>> UpdateAsync(UpdateGenreDto entity)
    {
        try
        {
            if (entity == null)
                return _responseCreator.CreateBaseBadRequest<string>("Genre is empty.");
                
            if (await Repository.ExistsAsync(entity.Id) == false)
                return _responseCreator.CreateBaseNotFound<string>($"Genre with id {entity.Id} not found.");
                
            await Repository.UpdateAsync(_mapper.Map<Genre>(entity));
            await _unitOfWork.SaveChangesAsync();
                
            return _responseCreator.CreateBaseOk("Genre updated.", 1);
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
                
            if (await Repository.ExistsAsync(id) == false)
                return _responseCreator.CreateBaseNotFound<string>($"Genre with id {id} not found.");
                
            await Repository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
                
            return _responseCreator.CreateBaseOk("Genre deleted.", 1);
        }
        catch (Exception e)
        {
            return _responseCreator.CreateBaseServerError<string>(e.Message);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cinema.BLL.Helpers;
using Cinema.BLL.Services.Interfaces;
using Cinema.DAL.Infrastructure.Interfaces;
using Cinema.DAL.Repositories.Interfaces;
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
    
    public async Task<IBaseResponse<List<GetScreeningDto>>> GetAsync()
    {
        try
        {
            var screeningsFromDatabase = await Repository.GetAsync();
                
            if (screeningsFromDatabase.Count == 0)
                return _responseCreator.CreateBaseNotFound<List<GetScreeningDto>>("No screenings found.");
                
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
                
            if (await Repository.ExistsAsync(id) == false)
                return _responseCreator.CreateBaseNotFound<GetScreeningDto>($"Screening with id {id} not found.");
                
            var screeningDto = _mapper.Map<GetScreeningDto>(await Repository.GetByIdAsync(id));

            return _responseCreator.CreateBaseOk(screeningDto, 1);
        }
        catch (Exception e)
        {
            return _responseCreator.CreateBaseServerError<GetScreeningDto>(e.Message);
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
                
            if (await Repository.ExistsAsync(entity.Id) == false)
                return _responseCreator.CreateBaseNotFound<string>($"Screening with id {entity.Id} not found.");
                
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
                
            if (await Repository.ExistsAsync(id) == false)
                return _responseCreator.CreateBaseNotFound<string>($"Screening with id {id} not found.");
                
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
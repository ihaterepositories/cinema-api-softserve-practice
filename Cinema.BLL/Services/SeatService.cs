using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cinema.BLL.Helpers;
using Cinema.BLL.Services.Interfaces;
using Cinema.DAL.Infrastructure.Interfaces;
using Cinema.DAL.Repositories.Interfaces;
using Cinema.Data.DTOs.SeatDTOs;
using Cinema.Data.Models;
using Cinema.Data.Responses.Interfaces;

namespace Cinema.BLL.Services;

public class SeatService : ISeatService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ResponseCreator _responseCreator;

    private ISeatRepository Repository => _unitOfWork.SeatRepository;

    public SeatService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _responseCreator = new ResponseCreator();
    }

    public async Task<IBaseResponse<List<GetSeatDto>>> GetAsync()
    {
        try
        {
            var seatsFromDatabase = await Repository.GetAsync();

            if (seatsFromDatabase.Count == 0)
                return _responseCreator.CreateBaseNotFound<List<GetSeatDto>>("No seats found.");

            var seatsDto = _mapper.Map<List<GetSeatDto>>(seatsFromDatabase);

            return _responseCreator.CreateBaseOk(seatsDto, seatsDto.Count);
        }
        catch (Exception e)
        {
            return _responseCreator.CreateBaseServerError<List<GetSeatDto>>(e.Message);
        }
    }

    public async Task<IBaseResponse<GetSeatDto>> GetByIdAsync(Guid id)
    {
        try
        {
            if (id == Guid.Empty)
                return _responseCreator.CreateBaseBadRequest<GetSeatDto>("Id is empty.");

            var seatDto = _mapper.Map<GetSeatDto>(await Repository.GetByIdAsync(id));

            if (seatDto == null)
                return _responseCreator.CreateBaseNotFound<GetSeatDto>($"Seat with id {id} not found.");

            return _responseCreator.CreateBaseOk(seatDto, 1);
        }
        catch (Exception e)
        {
            return _responseCreator.CreateBaseServerError<GetSeatDto>(e.Message);
        }
    }

    public async Task<IBaseResponse<string>> InsertAsync(AddSeatDto entity)
    {
        try
        {
            if (entity == null)
                return _responseCreator.CreateBaseBadRequest<string>("Seat is empty.");

            await Repository.InsertAsync(_mapper.Map<Seat>(entity));
            await _unitOfWork.SaveChangesAsync();

            return _responseCreator.CreateBaseOk($"Seat added.", 1);
        }
        catch (Exception e)
        {
            return _responseCreator.CreateBaseServerError<string>(e.Message);
        }
    }

    public async Task<IBaseResponse<string>> UpdateAsync(UpdateSeatDto entity)
    {
        try
        {
            if (entity == null)
                return _responseCreator.CreateBaseBadRequest<string>("Seat is empty.");

            await Repository.UpdateAsync(_mapper.Map<Seat>(entity));
            await _unitOfWork.SaveChangesAsync();

            return _responseCreator.CreateBaseOk("Seat updated.", 1);
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

            return _responseCreator.CreateBaseOk("Seat deleted.", 1);
        }
        catch (Exception e)
        {
            return _responseCreator.CreateBaseServerError<string>(e.Message);
        }
    }
}
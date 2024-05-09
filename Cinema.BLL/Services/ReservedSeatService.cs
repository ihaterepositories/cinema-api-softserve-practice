using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cinema.BLL.Helpers;
using Cinema.BLL.Services.Interfaces;
using Cinema.DAL.Infrastructure.Interfaces;
using Cinema.DAL.Repositories.Interfaces;
using Cinema.Data.DTOs.ReservedSeatDTOs;
using Cinema.Data.Models;
using Cinema.Data.Responses.Interfaces;

namespace Cinema.BLL.Services;

public class ReservedSeatService : IReservedSeatService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ResponseCreator _responseCreator;

    private IReservedSeatRepository Repository => _unitOfWork.ReservedSeatRepository;

    public ReservedSeatService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _responseCreator = new ResponseCreator();
    }

    public async Task<IBaseResponse<List<GetReservedSeatDto>>> GetAsync()
    {
        try
        {
            var reservedSeatsFromDatabase = await Repository.GetAsync();

            if (reservedSeatsFromDatabase.Count == 0)
                return _responseCreator.CreateBaseNotFound<List<GetReservedSeatDto>>("No reserved seats found.");

            var reservedSeatsDto = _mapper.Map<List<GetReservedSeatDto>>(reservedSeatsFromDatabase);

            return _responseCreator.CreateBaseOk(reservedSeatsDto, reservedSeatsDto.Count);
        }
        catch (Exception e)
        {
            return _responseCreator.CreateBaseServerError<List<GetReservedSeatDto>>(e.Message);
        }
    }

    public async Task<IBaseResponse<GetReservedSeatDto>> GetByIdAsync(Guid id)
    {
        try
        {
            if (id == Guid.Empty)
                return _responseCreator.CreateBaseBadRequest<GetReservedSeatDto>("Id is empty.");

            var reservedSeatDto = _mapper.Map<GetReservedSeatDto>(await Repository.GetByIdAsync(id));

            if (reservedSeatDto == null)
                return _responseCreator.CreateBaseNotFound<GetReservedSeatDto>($"Reserved seat with id {id} not found.");

            return _responseCreator.CreateBaseOk(reservedSeatDto, 1);
        }
        catch (Exception e)
        {
            return _responseCreator.CreateBaseServerError<GetReservedSeatDto>(e.Message);
        }
    }

    public async Task<IBaseResponse<string>> InsertAsync(AddReservedSeatDto entity)
    {
        try
        {
            if (entity == null)
                return _responseCreator.CreateBaseBadRequest<string>("Reserved seat is empty.");

            await Repository.InsertAsync(_mapper.Map<ReservedSeat>(entity));
            await _unitOfWork.SaveChangesAsync();

            return _responseCreator.CreateBaseOk($"Reserved seat added.", 1);
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

            return _responseCreator.CreateBaseOk("Reserved seat deleted.", 1);
        }
        catch (Exception e)
        {
            return _responseCreator.CreateBaseServerError<string>(e.Message);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cinema.BLL.Helpers;
using Cinema.BLL.Services.Interfaces;
using Cinema.DAL.Infrastructure.Interfaces;
using Cinema.DAL.Repositories.Interfaces;
using Cinema.Data.DTOs.ActorDTOs;
using Cinema.Data.Models;
using Cinema.Data.Responses.Interfaces;

namespace Cinema.BLL.Services
{
    public class ActorService : IActorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseCreator _responseCreator;

        private IActorRepository Repository => _unitOfWork.ActorRepository;

        public ActorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _responseCreator = new ResponseCreator();
        }

        public async Task<IBaseResponse<List<GetActorDto>>> GetAsync()
        {
            try
            {
                var actorsFromDatabase = await Repository.GetAsync();

                if (actorsFromDatabase.Count == 0)
                    return _responseCreator.CreateBaseNotFound<List<GetActorDto>>("No actors found.");

                var actorsDto = _mapper.Map<List<GetActorDto>>(actorsFromDatabase);

                return _responseCreator.CreateBaseOk(actorsDto, actorsDto.Count);
            }
            catch (Exception e)
            {
                return _responseCreator.CreateBaseServerError<List<GetActorDto>>(e.Message);
            }
        }

        public async Task<IBaseResponse<GetActorDto>> GetByIdAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return _responseCreator.CreateBaseBadRequest<GetActorDto>("Id is empty.");

                var actorDto = _mapper.Map<GetActorDto>(await Repository.GetByIdAsync(id));

                if (actorDto == null)
                    return _responseCreator.CreateBaseNotFound<GetActorDto>($"Actor with id {id} not found.");

                return _responseCreator.CreateBaseOk(actorDto, 1);
            }
            catch (Exception e)
            {
                return _responseCreator.CreateBaseServerError<GetActorDto>(e.Message);
            }
        }

        public async Task<IBaseResponse<string>> InsertAsync(AddActorDto entity)
        {
            try
            {
                if (entity == null)
                    return _responseCreator.CreateBaseBadRequest<string>("Actor is empty.");

                await Repository.InsertAsync(_mapper.Map<Actor>(entity));
                await _unitOfWork.SaveChangesAsync();

                return _responseCreator.CreateBaseOk($"Actor added.", 1);
            }
            catch (Exception e)
            {
                return _responseCreator.CreateBaseServerError<string>(e.Message);
            }
        }

        public async Task<IBaseResponse<string>> UpdateAsync(UpdateActorDto entity)
        {
            try
            {
                if (entity == null)
                    return _responseCreator.CreateBaseBadRequest<string>("Actor is empty.");

                await Repository.UpdateAsync(_mapper.Map<Actor>(entity));
                await _unitOfWork.SaveChangesAsync();

                return _responseCreator.CreateBaseOk("Actor updated.", 1);
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

                return _responseCreator.CreateBaseOk("Actor deleted.", 1);
            }
            catch (Exception e)
            {
                return _responseCreator.CreateBaseServerError<string>(e.Message);
            }
        }
    }
}
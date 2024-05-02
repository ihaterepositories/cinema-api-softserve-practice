using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cinema.BLL.Services.Interfaces;
using Cinema.DAL.Infrastructure.Interfaces;
using Cinema.Data.DTOs.ActorDTOs;
using Cinema.Data.Models;

namespace Cinema.BLL.Services
{
    public class ActorService : IActorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ActorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _unitOfWork.ActorRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetActorDto>> GetAsync()
        {
            var actorsFromDatabase = await _unitOfWork.ActorRepository.GetAsync();
            var actorsDTO = _mapper.Map<List<GetActorDto>>(actorsFromDatabase);

            return actorsDTO;
        }

        public async Task<GetActorDto> GetByIdAsync(Guid id)
        {
            var actorFromDatabase = await _unitOfWork.ActorRepository.GetByIdAsync(id);
            var actorDTO = _mapper.Map<GetActorDto>(actorFromDatabase);

            return actorDTO;
        }

        public async Task InsertAsync(AddActorDto entity)
        {
            var insertedActor = _mapper.Map<Actor>(entity);
            await _unitOfWork.ActorRepository.InsertAsync(insertedActor);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateActorDto entity)
        {
            var updatedActor = _mapper.Map<Actor>(entity);
            await _unitOfWork.ActorRepository.UpdateAsync(updatedActor);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
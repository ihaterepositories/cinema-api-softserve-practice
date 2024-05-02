using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Data.DTOs.ActorDTOs;

namespace Cinema.BLL.Services.Interfaces
{
    public interface IActorService
    {
        Task<IEnumerable<GetActorDto>> GetAsync();
        Task<GetActorDto> GetByIdAsync(Guid id);
        Task InsertAsync(AddActorDto entity);
        Task UpdateAsync(UpdateActorDto entity);
        Task DeleteAsync(Guid id);
    }
}
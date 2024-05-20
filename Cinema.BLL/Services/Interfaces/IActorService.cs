using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinema.Data.DTOs.ActorDTOs;
using Cinema.Data.Responses.Interfaces;

namespace Cinema.BLL.Services.Interfaces
{
    public interface IActorService
    {
        Task<IBaseResponse<List<GetActorDto>>> GetAsync();
        Task<IBaseResponse<GetActorDto>> GetByIdAsync(Guid id);
        Task<IBaseResponse<string>> InsertAsync(AddActorDto entity);
        Task<IBaseResponse<string>> UpdateAsync(UpdateActorDto entity);
        Task<IBaseResponse<string>> DeleteAsync(Guid id);
    }
}
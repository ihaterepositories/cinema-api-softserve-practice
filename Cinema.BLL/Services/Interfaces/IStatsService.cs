using Cinema.Data.DTOs.MovieDTOs;
using Cinema.Data.DTOs.StatsDTOs;
using Cinema.Data.Responses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.BLL.Services.Interfaces
{
    public interface IStatsService
    {
        Task<IBaseResponse<GetMovieSellsStatsDTO>> GetMovieSellsStatsAsync(Guid movieId);
        Task<IBaseResponse<List<GetRevenueByDayDTO>>> GetRevenueByDayAsync(DateOnly date);
    }
}

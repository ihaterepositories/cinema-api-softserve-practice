using Cinema.Data.DTOs.MovieDTOs;
using Cinema.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Data.DTOs.StatsDTOs
{
    public class GetMovieSellsStatsDTO
    {
        public GetMovieDto Movie { get; set; } = null!;
        public List<ScreeningIncomeDTO> screeningIncome { get; set; }=new List<ScreeningIncomeDTO>();
    }
}

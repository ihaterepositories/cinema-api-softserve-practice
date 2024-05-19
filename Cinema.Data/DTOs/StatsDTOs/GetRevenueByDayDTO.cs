using Cinema.Data.DTOs.ScreeningDTOs;
using Cinema.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Data.DTOs.StatsDTOs
{
    public class GetRevenueByDayDTO
    {
        public GetScreeningDto screening { get; set; } = null!;
        public double Revenue { get; set; }
    }
}

using Cinema.Data.DTOs.ScreeningDTOs;
using Cinema.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Data.DTOs.StatsDTOs
{
    public class ScreeningIncomeDTO
    {
        public GetScreeningDto screening { get; set; } = null!;
        public double Income { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Data.Models
{
    public class User : IdentityUser<Guid>
    {
        public ICollection<Reservation> Reservations { get; } = new List<Reservation>();
    }
}

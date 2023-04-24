using MyPlace.BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace.BusinessLogic.Dtos
{
    public class ReservationDto
    {
        public Guid ReservationCode { get; set; } = Guid.NewGuid();
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now.AddDays(7)) ;
        public Office? Office { get; set; }
        public int OfficeId { get; set; }
        public User User { get; set; } = new User();
        public int UserId { get; set; } 
    }
}

using MyPlace.BusinessLogic.Entities;

namespace MyPlace.MyPlaceApi.Models
{
    public class LightReservationDto
    {
        public Guid ReservationCode { get; set; } = Guid.NewGuid();
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now.AddDays(7));
        public int OfficeId { get; set; }
        public int UserId { get; set; }
    }
}

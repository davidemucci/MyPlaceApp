using System.ComponentModel.DataAnnotations;


namespace MyPlace.MyPlaceApi.Models
{
    public class ReservationForManipulationDto
    {
        public Guid ReservationCode { get; set; } = new Guid();

        [Required(ErrorMessage = "You shold select a Date for the reservation")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "You shold select an office for the reservation")]
        public int OfficeId { get; set; }
        [Required(ErrorMessage = "You shold select an user for the reservation")]
        public int UserId { get; set; }
    }
}
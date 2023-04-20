namespace MyPlace.BusinessLogic.Entities
{
    public class Reservation : IEntity
    {

        public int Id { get; set; }
        public Guid ReservationCode { get; set; } = Guid.NewGuid();
        public DateOnly Date { get; set; }
        public int? OfficeId { get; set; }
        public Office? Office { get; set; } 
        public int UserId { get; set; }
        public User? User { get; set; }
        
    }
}
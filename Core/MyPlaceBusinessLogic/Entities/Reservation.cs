namespace MyPlace.BusinessLogic.Entities
{
    public class Reservation : IEntity
    {
        public int Id { get; set; }
        public Guid ReservationCode { get; set; }
        public DateOnly Date { get; set; }
        public int OfficeId { get; set; }
        // public int UserId
    }
}
namespace MyPlace.BusinessLogic.Entities
{
    public class Office : IEntity
    {
        public int Id { get ; set ; }
        public string Name { get; set; } = string.Empty;
        public int? Floor { get; set; }
        public int MaxCapacity { get; set; }
        public  bool IsAvailable { get; set; } = true;
        public int BuildingId { get; set; }
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}
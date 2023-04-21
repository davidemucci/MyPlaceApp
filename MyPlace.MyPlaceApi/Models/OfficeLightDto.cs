using MyPlace.BusinessLogic.Entities;

namespace MyPlace.MyPlaceApi.Models
{
    public class OfficeLightDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? Floor { get; set; }
        public int MaxCapacity { get; set; }
        public int? BuildingId { get; set; }
        //public Building? Building { get; set; }
    }
}

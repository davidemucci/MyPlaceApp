using MyPlace.BusinessLogic.Entities;

namespace MyPlace.MyPlaceApi.Models
{
    public class BuildingLightDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; }
        public int FloorsNumber { get; set; } = 1;

        //public List<Office>? Offices { get; set; } = new List<Office>();
    }
}
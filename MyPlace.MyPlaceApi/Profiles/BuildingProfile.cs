using AutoMapper;
using MyPlace.BusinessLogic.Entities;
using MyPlace.MyPlaceApi.Models;

namespace MyPlace.MyPlaceApi.Profiles
{
    public class BuildingProfile : Profile
    {
        public BuildingProfile() {
            CreateMap<Building, BuildingLightDto>();
        }
    }
}

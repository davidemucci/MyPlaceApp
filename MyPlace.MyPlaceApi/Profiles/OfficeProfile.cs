using AutoMapper;
using MyPlace.BusinessLogic.Entities;
using MyPlace.MyPlaceApi.Models;

namespace MyPlace.MyPlaceApi.Profiles
{
    public class OfficeProfile : Profile
    {
        public OfficeProfile()
        {
            CreateMap<Office, OfficeLightDto>();
        }
    }
}

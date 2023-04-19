﻿using AutoMapper;
using MyPlace.BusinessLogic.Dtos;
using MyPlace.BusinessLogic.Entities;
using MyPlace.MyPlaceApi.Models;

namespace MyPlace.MyPlaceApi.Profiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<Reservation, ReservationDto>().ReverseMap();
            CreateMap<Reservation, LightReservationDto>().ReverseMap();
        }

    }
}

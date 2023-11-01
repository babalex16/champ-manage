﻿using AutoMapper;

namespace ChampManage.API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Entities.User, Models.UserDto>();
            CreateMap<Models.UserForCreationDto, Entities.User>();
            CreateMap<Models.UserProfileCreationDto, Entities.User>();
            CreateMap<Entities.User, Models.UserProfileCreationDto>();
        }
    }
}
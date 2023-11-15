using AutoMapper;
using ChampManage.API.Entities;
using ChampManage.API.Models;

namespace ChampManage.API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Entities.User, Models.UserDto>();
            CreateMap<Models.UserProfileCreationDto, Entities.User>();
            CreateMap<Entities.User, Models.UserProfileCreationDto>();
            CreateMap<Entities.User, Models.UserPublicDto>();
        }
    }
}

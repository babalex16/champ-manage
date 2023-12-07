using AutoMapper;
using ChampManage.API.Entities;
using ChampManage.API.Models.UserModels;

namespace ChampManage.API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserProfileCreationDto, User>();
            CreateMap<User, UserProfileCreationDto>();
            CreateMap<User, UserPublicDto>();
        }
    }
}

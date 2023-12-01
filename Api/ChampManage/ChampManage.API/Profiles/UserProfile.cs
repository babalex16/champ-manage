using AutoMapper;
using ChampManage.API.Entities;
using ChampManage.API.Models.UserModels;

namespace ChampManage.API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Entities.User, UserDto>();
            CreateMap<UserProfileCreationDto, Entities.User>();
            CreateMap<Entities.User, UserProfileCreationDto>();
            CreateMap<Entities.User, UserPublicDto>();
        }
    }
}

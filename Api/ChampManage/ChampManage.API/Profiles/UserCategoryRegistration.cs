using AutoMapper;
using ChampManage.API.Models;

namespace ChampManage.API.Profiles
{
    public class UserCategoryRegistration : Profile
    {
        public UserCategoryRegistration()
        {
            CreateMap<UserCategoryRegistrationDto, UserCategoryRegistration>();
            CreateMap<UserCategoryRegistration,  UserCategoryRegistrationDto>();
        }
    }

}

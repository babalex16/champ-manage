using AutoMapper;
using ChampManage.API.Models.UserModels;

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

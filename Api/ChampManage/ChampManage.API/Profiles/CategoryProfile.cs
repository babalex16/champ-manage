using AutoMapper;
using ChampManage.API.Models;

namespace ChampManage.API.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() {
            CreateMap<Entities.Category, CategoryDto>();        
        }
    }
}

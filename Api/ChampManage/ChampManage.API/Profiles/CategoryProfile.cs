using AutoMapper;
using ChampManage.API.Models.CategoryModels;

namespace ChampManage.API.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() {
            CreateMap<Entities.Category, CategoryDto>();
            CreateMap<CategoryDto, Entities.Category>();
        }
    }
}

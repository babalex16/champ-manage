using AutoMapper;
using ChampManage.API.Models.NewsModels;

namespace ChampManage.API.Profiles
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
            CreateMap<Entities.News, NewsDto>();
            CreateMap<NewsDto, Entities.News>();
        }
    }
}

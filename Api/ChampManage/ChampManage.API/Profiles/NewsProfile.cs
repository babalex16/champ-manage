using AutoMapper;
using ChampManage.API.Models;

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

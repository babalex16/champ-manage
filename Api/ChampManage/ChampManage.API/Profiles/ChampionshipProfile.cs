using AutoMapper;
using ChampManage.API.Entities;
using ChampManage.API.Models.ChampionshipModels;

namespace ChampManage.API.Profiles
{
    public class ChampionshipProfile : Profile
    {
        public ChampionshipProfile()
        {
            CreateMap<Championship, ChampionshipDto>();
            CreateMap<ChampionshipForCreationDto, Championship>();
            CreateMap<ChampionshipForUpdateDto, Championship>();
            CreateMap<Championship, ChampionshipForUpdateDto>();
        }
    }
}

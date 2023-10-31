using AutoMapper;

namespace ChampManage.API.Profiles
{
    public class ChampionshipProfile : Profile
    {
        public ChampionshipProfile()
        {
            CreateMap<Entities.Championship, Models.ChampionshipDto>();
        }
    }
}

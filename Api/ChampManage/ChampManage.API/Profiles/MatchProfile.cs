using AutoMapper;

namespace ChampManage.API.Profiles
{
    public class MatchProfile : Profile
    {
        public MatchProfile() { 
            CreateMap<Entities.Match, Models.MatchDto>();
        }
    }
}

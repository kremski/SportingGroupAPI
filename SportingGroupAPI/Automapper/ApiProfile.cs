using AutoMapper;
using SportingGroupAPI.DAL.Models;
using SportingGroupAPI.Models;

namespace SportingGroupAPI.Automapper
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<Fixture, ApiGetFixture>()
                .ForMember(dest => dest.HostTeam, opt => opt.MapFrom(src => src.HostTeam))
                .ForMember(dest => dest.GuestTeam, opt => opt.MapFrom(src => src.GuestTeam))
                .ForMember(dest => dest.Result, opt => opt.MapFrom(src => src.Result));
            CreateMap<Result, ApiResult>();
            CreateMap<Team, ApiTeam>();
        }
    }
}

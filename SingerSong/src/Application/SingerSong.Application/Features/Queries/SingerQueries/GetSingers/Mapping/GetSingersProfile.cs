using SingerSong.Application.Features.Queries.SingerQueries.GetSingers.Models;

namespace SingerSong.Application.Features.Queries.SingerQueries.GetSingers.Mapping;

internal class GetSingersProfile : Profile
{
    public GetSingersProfile()
    {
        CreateMap<Singer, GetSingersResponse>()
            .ForMember(dest => dest.MusicStyle, opt => opt.MapFrom(src => src.MusicStyle.ToString()))
            .ForMember(dest => dest.SingerType, opt => opt.MapFrom(src => src.SingerType.ToString()))
            .ForMember(dest => dest.SingerID, opt => opt.MapFrom(src => src.Id.ToString()));
    }
}


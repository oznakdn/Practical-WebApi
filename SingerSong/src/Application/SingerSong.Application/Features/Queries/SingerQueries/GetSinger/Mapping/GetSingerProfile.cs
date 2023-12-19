using AutoMapper;
using SingerSong.Application.Features.Queries.SingerQueries.GetSinger.Models;
using SingerSong.Domain.Entities;

namespace SingerSong.Application.Features.Queries.SingerQueries.GetSinger.Mapping;

internal class GetSingerProfile : Profile
{
    public GetSingerProfile()
    {
        CreateMap<Singer, GetSingerResponse>()
           .ForMember(dest => dest.MusicStyle, opt => opt.MapFrom(src => src.MusicStyle.ToString()))
           .ForMember(dest => dest.SingerType, opt => opt.MapFrom(src => src.SingerType.ToString()))
           .ForMember(dest => dest.SingerID, opt => opt.MapFrom(src => src.Id.ToString()));
    }

}


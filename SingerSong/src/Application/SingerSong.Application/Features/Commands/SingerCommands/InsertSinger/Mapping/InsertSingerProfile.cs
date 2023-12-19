using AutoMapper;
using SingerSong.Application.Features.Commands.SingerCommands.InsertSinger.Models;
using SingerSong.Domain.Entities;

namespace SingerSong.Application.Features.Commands.SingerCommands.InsertSinger.Mapping;

internal class InsertSingerProfile : Profile
{
    public InsertSingerProfile()
    {
        CreateMap<InsertSingerRequest, Singer>();
        CreateMap<Singer,InsertSingerResponse>()
            .ForMember(dest=>dest.MusicStyle,opt=>opt.MapFrom(src=>src.MusicStyle.ToString()))
            .ForMember(dest => dest.SingerType, opt => opt.MapFrom(src => src.SingerType.ToString()));

    }
}


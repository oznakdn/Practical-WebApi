using SingerSong.Application.Features.Commands.SingerCommands.UpdateSinger.Models;

namespace SingerSong.Application.Features.Commands.SingerCommands.UpdateSinger.Mapping;

internal class UpdateSingerProfile : Profile
{
    public UpdateSingerProfile()
    {
        CreateMap<Singer, UpdateSingerResponse>()
            .ForMember(dest => dest.SingerType, opt => opt.MapFrom(src => src.SingerType.ToString()))
            .ForMember(dest => dest.MusicStyle, opt => opt.MapFrom(src => src.MusicStyle.ToString()));
    }
}


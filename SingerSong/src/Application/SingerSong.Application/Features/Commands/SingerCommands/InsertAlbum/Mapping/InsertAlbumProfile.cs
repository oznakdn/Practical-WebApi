using AutoMapper;
using SingerSong.Application.Features.Commands.SingerCommands.InsertAlbum.Models;
using SingerSong.Domain.Entities;

namespace SingerSong.Application.Features.Commands.SingerCommands.InsertAlbum.Mapping;

internal class InsertAlbumProfile : Profile
{
    public InsertAlbumProfile()
    {
        CreateMap<InsertAlbumRequest, Album>()
            .ForMember(dest => dest.SingerID, opt => opt.MapFrom(src => Guid.Parse(src.SingerID)));

        CreateMap<Album, InsertAlbumResponse>()
            .ForMember(dest => dest.SingerID, opt => opt.MapFrom(src => src.SingerID.ToString()));
    }
}


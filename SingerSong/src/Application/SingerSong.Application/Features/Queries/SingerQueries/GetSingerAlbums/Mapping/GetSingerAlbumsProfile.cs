using AutoMapper;
using SingerSong.Application.Features.Queries.SingerQueries.GetSingerAlbums.Models;
using SingerSong.Domain.Entities;

namespace SingerSong.Application.Features.Queries.SingerQueries.GetSingerAlbums.Mapping;

internal class GetSingerAlbumsProfile : Profile
{
    public GetSingerAlbumsProfile()
    {
        CreateMap<Singer, GetSingerAlbumsResponse>()
            .ForMember(dest => dest.SingerID, opt => opt.MapFrom(src => src.Id.ToString()));

        CreateMap<Album, AlbumResponse>();
    }
}


using SingerSong.Application.Features.Queries.AlbumQueries.GetAlbum.Models;

namespace SingerSong.Application.Features.Queries.AlbumQueries.GetAlbum.Mapping;

internal class GetAlbumProfile : Profile
{
    public GetAlbumProfile()
    {
        CreateMap<Album, GetAlbumResponse>()
            .ForMember(dest => dest.SingerName, opt => opt.MapFrom(src => src.Singer.SingerName));
    }
}


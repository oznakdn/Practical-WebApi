using SingerSong.Application.Features.Queries.SingerQueries.GetSingerAlbumSongs.Models;

namespace SingerSong.Application.Features.Queries.SingerQueries.GetSingerAlbumSongs.Mapping;

public class GetSingerAlbumSongsProfile : Profile
{
    public GetSingerAlbumSongsProfile()
    {
        CreateMap<Singer, GetSingerAlbumSongsResponse>()
           .ForMember(dest => dest.SingerID, opt => opt.MapFrom(src => src.Id.ToString()));

        CreateMap<Album, AlbumResponseWithSongs>()
            .ForMember(dest => dest.AlbumID, opt => opt.MapFrom(src => src.Id.ToString()));

        CreateMap<Song, SongResponse>()
            .ForMember(dest => dest.SongID, opt => opt.MapFrom(src => src.Id.ToString()));

    }
}


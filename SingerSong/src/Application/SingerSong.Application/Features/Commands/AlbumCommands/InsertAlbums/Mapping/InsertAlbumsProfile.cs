using SingerSong.Application.Features.Commands.AlbumCommands.InsertAlbums.Models;

namespace SingerSong.Application.Features.Commands.AlbumCommands.InsertAlbums.Mapping;

internal class InsertAlbumsProfile : Profile
{
    public InsertAlbumsProfile()
    {
        CreateMap<Album, InsertAlbumsResponse>();
        CreateMap<InsertAlbum, Album>();
    }
}


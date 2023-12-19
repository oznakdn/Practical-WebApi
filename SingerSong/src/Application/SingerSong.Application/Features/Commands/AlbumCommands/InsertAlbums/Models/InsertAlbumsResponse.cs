namespace SingerSong.Application.Features.Commands.AlbumCommands.InsertAlbums.Models;

public record InsertAlbumsResponse
{
    public string AlbumName { get; init; }
    public int SongCount { get; init; }
    public string CoverPhoto { get; init; }
}


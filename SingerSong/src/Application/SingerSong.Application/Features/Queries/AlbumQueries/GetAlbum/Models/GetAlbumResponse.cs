namespace SingerSong.Application.Features.Queries.AlbumQueries.GetAlbum.Models;

public record GetAlbumResponse
{
    public string SingerName { get; init; }
    public string AlbumName { get; init; }
    public int SongCount { get; init; }
    public string CoverPhoto { get; init; }
}



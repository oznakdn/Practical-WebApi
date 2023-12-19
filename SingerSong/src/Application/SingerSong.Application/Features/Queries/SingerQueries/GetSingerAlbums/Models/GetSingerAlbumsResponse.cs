namespace SingerSong.Application.Features.Queries.SingerQueries.GetSingerAlbums.Models;

public record GetSingerAlbumsResponse
{
    public string SingerID { get; init; }
    public string SingerName { get; init; }
    public List<AlbumResponse> Albums { get; init; }
}

public record AlbumResponse
{
    public string AlbumName { get; init; }
    public int SongCount { get; init; }
    public string CoverPhoto { get; init; }
}


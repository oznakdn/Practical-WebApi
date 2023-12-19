namespace SingerSong.Application.Features.Queries.SingerQueries.GetSingerAlbumSongs.Models;

public record GetSingerAlbumSongsResponse
{
    public string SingerID { get; init; }
    public string SingerName { get; init; }
    public List<AlbumResponseWithSongs> Albums { get; init; }
}

public record AlbumResponseWithSongs
{
    public string AlbumID { get; init; }
    public string AlbumName { get; init; }
    public int SongCount { get; init; }
    public string CoverPhoto { get; init; }
    public List<SongResponse>Songs { get; init; }
}

public record SongResponse
{
    public string SongID { get; init; }
    public string SongName { get; init; }
    public float SongWeight { get; init; }
}



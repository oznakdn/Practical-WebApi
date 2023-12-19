namespace SingerSong.Console.Models.AlbumModels;

public record GetAlbumsResponse
{
    public string singerName { get; init; }
    public string albumName { get; init; }
    public int songCount { get; init; }
    public string coverPhoto { get; init; }
}


namespace SingerSong.Application.Features.Commands.SingerCommands.InsertAlbumSong.Models;

public record InsertAlbumSongResponse
{
    public string SingerId { get; init; }
    public string AlbumId { get; init; }
    public string SongName { get; init; }
    public float SongWeight { get; init; }
}


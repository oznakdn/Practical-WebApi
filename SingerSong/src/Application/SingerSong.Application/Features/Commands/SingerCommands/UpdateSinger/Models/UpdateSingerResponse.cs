namespace SingerSong.Application.Features.Commands.SingerCommands.UpdateSinger.Models;

public record UpdateSingerResponse
{
    public string SingerName { get; init; }
    public string SingerType { get; init; }
    public string MusicStyle { get; init; }
    public string SingerPhoto { get; init; }
    public string SingerAbout { get; init; }
    public string Location { get; init; }
}


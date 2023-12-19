namespace SingerSong.Application.Features.Queries.SingerQueries.GetSinger.Models;

public record GetSingerResponse
{
    public string SingerID { get; init; }
    public string SingerName { get; init; }
    public string SingerType { get; init; }
    public string MusicStyle { get; init; }
    public string SingerPhoto { get; init; }
    public string SingerAbout { get; init; }
    public string Location { get; init; }
}


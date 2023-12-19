namespace SingerSong.Application.Features.Commands.SingerCommands.InsertSinger.Models;

public record InsertSingerRequest(string SingerName, SingerType SingerType, MusicStyle MusicStyle, string SingerPhoto, string SingerAbout, string Location) : IRequest<IDataResult<InsertSingerResponse>>;



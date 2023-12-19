namespace SingerSong.Application.Features.Commands.SingerCommands.UpdateSinger.Models;

public record UpdateSingerRequest(string SingerId, string SingerName, SingerType SingerType, MusicStyle MusicStyle, string SingerPhoto, string SingerAbout, string Location) : IRequest<IDataResult<UpdateSingerResponse>>;



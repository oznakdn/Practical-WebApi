namespace SingerSong.Application.Features.Commands.SingerCommands.RemoveSinger.Models;

public record RemoveSingerRequest(string singerId) : IRequest<IDataResult<RemoveSingerResponse>>;



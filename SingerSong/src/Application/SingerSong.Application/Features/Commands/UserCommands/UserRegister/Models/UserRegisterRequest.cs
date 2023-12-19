namespace SingerSong.Application.Features.Commands.UserCommands.UserRegister.Models;

public record UserRegisterRequest(string Email, string Password) : IRequest<IDataResult<string>>;




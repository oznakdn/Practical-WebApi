using SingerSong.Application.Security.Abstracts;

namespace SingerSong.Application.Features.Commands.UserCommands.UserLogin.Models;

public record UserLoginRequest(string Email, string Password) : IRequest<IDataResult<ITokenResponse>>;




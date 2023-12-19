using SingerSong.Application.Features.Commands.UserCommands.UserLogin.Models;
using SingerSong.Application.Features.Commands.UserCommands.UserLogin.Validation;
using SingerSong.Application.Security.Abstracts;

namespace SingerSong.Application.Features.Commands.UserCommands.UserLogin.Handler;

public class UserLoginHandler : IRequestHandler<UserLoginRequest, IDataResult<ITokenResponse>>
{
    private readonly IUnitOfWorkQuery _query;
    private readonly IUnitOfWorkCommand _command;
    private readonly IJwtHandler _jwtHandler;
    public UserLoginHandler(IUnitOfWorkQuery query, IUnitOfWorkCommand command, IJwtHandler jwtHandler)
    {
        _query = query;
        _command = command;
        _jwtHandler = jwtHandler;
    }

    public async Task<IDataResult<ITokenResponse>> Handle(UserLoginRequest request, CancellationToken cancellationToken)
    {
        UserLoginValidator validator = new();
        var validationResult = validator.Validate(request);
        List<string> errors = new();
        if (!validationResult.IsValid)
        {
            validationResult.Errors.ForEach(error => errors.Add(error.ErrorMessage));
            return new DataResult<ITokenResponse>(errors, false);
        }

        var currentUser = await _query.UserQuery().GetAsync(x => x.Email.Equals(request.Email) && x.Password.Equals(request.Password));
        if (currentUser == null) return new DataResult<ITokenResponse>("User not found!", false);

        var token = _jwtHandler.GenerateAccessToken(currentUser,2);
        currentUser.RefreshToken = token.RefreshToken;
        currentUser.TokenExpiredTime = token.ExpiredTime;
        _command.UserCommand().Edit(currentUser);
        await _command.SaveAsync();
        return new DataResult<ITokenResponse>(token);

    }
}


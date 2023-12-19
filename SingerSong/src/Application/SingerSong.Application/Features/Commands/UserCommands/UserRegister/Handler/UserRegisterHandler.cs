using SingerSong.Application.Features.Commands.UserCommands.UserRegister.Models;
using SingerSong.Application.Features.Commands.UserCommands.UserRegister.Validation;
using SingerSong.Domain.Identities;

namespace SingerSong.Application.Features.Commands.UserCommands.UserRegister.Handler;
public sealed class UserRegisterHandler : IRequestHandler<UserRegisterRequest, IDataResult<string>>
{
    private readonly IUnitOfWorkQuery _query;
    private readonly IUnitOfWorkCommand _command;
    private readonly IMapper _mapper;
    public UserRegisterHandler(IUnitOfWorkQuery query, IMapper mapper, IUnitOfWorkCommand command)
    {
        _query = query;
        _mapper = mapper;
        _command = command;
    }

    public async Task<IDataResult<string>> Handle(UserRegisterRequest request, CancellationToken cancellationToken)
    {
        var existUser = await _query.UserQuery().AnyAsync(x=>x.Email == request.Email);
        if (existUser) return new DataResult<string>("You could not use this mail!",false);

        UserRegisterValidator validator = new();
        List<string> errors = new();
        var validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            validationResult.Errors.ForEach(error => errors.Add(error.ErrorMessage));
            return new DataResult<string>(errors,false);
        }

        _command.UserCommand().Insert(_mapper.Map<User>(request));
        await _command.SaveAsync();
        return new DataResult<string>("You are register.",true);

    }
}


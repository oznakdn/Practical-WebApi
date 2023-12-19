using SingerSong.Application.Features.Commands.SingerCommands.RemoveSinger.Models;
using SingerSong.Application.Features.Commands.SingerCommands.RemoveSinger.Validation;

namespace SingerSong.Application.Features.Commands.SingerCommands.RemoveSinger.Handler;

public sealed class RemoveSingerHandler : IRequestHandler<RemoveSingerRequest, IDataResult<RemoveSingerResponse>>
{
    private readonly IUnitOfWorkQuery _query;
    private readonly IUnitOfWorkCommand _command;

    public RemoveSingerHandler(IUnitOfWorkQuery query, IUnitOfWorkCommand command)
    {
        _query = query;
        _command = command;
    }

    public async Task<IDataResult<RemoveSingerResponse>> Handle(RemoveSingerRequest request, CancellationToken cancellationToken)
    {
        RemoveSingerValidator validator = new();
        var validationResult = validator.Validate(request);
        List<string> errors = new();

        validationResult.Errors.ForEach(error => errors.Add(error.ErrorMessage));
        if (!validationResult.IsValid) return new DataResult<RemoveSingerResponse>(errors, false);

        var currentSinger = await _query.SingerQuery().GetAsync(x => x.Id.Equals(Guid.Parse(request.singerId)) && x.IsActive);
        if (currentSinger is null) return new DataResult<RemoveSingerResponse>("Singer not found!", false);

        _command.SingerCommand().Remove(currentSinger);
        await _command.SaveAsync();
        return new DataResult<RemoveSingerResponse>("Singer has been deleted!", true);

    }
}


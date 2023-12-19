using SingerSong.Application.Features.Commands.SingerCommands.InsertSinger.Models;
using SingerSong.Application.Features.Commands.SingerCommands.InsertSinger.Validation;

namespace SingerSong.Application.Features.Commands.SingerCommands.InsertSinger.Handler;

public sealed class InsertSingerHandler : IRequestHandler<InsertSingerRequest, IDataResult<InsertSingerResponse>>
{
    private readonly IUnitOfWorkCommand _command;
    private readonly IMapper _mapper;

    public InsertSingerHandler(IUnitOfWorkCommand command, IMapper mapper)
    {
        _command = command;
        _mapper = mapper;
    }

    public async Task<IDataResult<InsertSingerResponse>> Handle(InsertSingerRequest request, CancellationToken cancellationToken)
    {
        InsertSingerValidator validator = new();
        List<string> errors = new();
        var validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            validationResult.Errors.ForEach(error => errors.Add(error.ErrorMessage));
            return new DataResult<InsertSingerResponse>(errors, false);
        }

        Singer singer = _mapper.Map<Singer>(request);
        _command.SingerCommand().Insert(singer);
        await _command.SaveAsync();
        return new DataResult<InsertSingerResponse>(_mapper.Map<InsertSingerResponse>(singer),"Singer was created.");
    }

}


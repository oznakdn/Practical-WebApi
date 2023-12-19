using SingerSong.Application.Features.Commands.SingerCommands.UpdateSinger.Models;
using SingerSong.Application.Features.Commands.SingerCommands.UpdateSinger.Validation;

namespace SingerSong.Application.Features.Commands.SingerCommands.UpdateSinger.Handler;

public sealed class UpdateSingerHandler : IRequestHandler<UpdateSingerRequest, IDataResult<UpdateSingerResponse>>
{
    private readonly IUnitOfWorkCommand _command;
    private readonly IUnitOfWorkQuery _query;
    private readonly IMapper _mapper;

    public UpdateSingerHandler(IUnitOfWorkCommand command, IUnitOfWorkQuery query, IMapper mapper)
    {
        _command = command;
        _query = query;
        _mapper = mapper;
    }

    public async Task<IDataResult<UpdateSingerResponse>> Handle(UpdateSingerRequest request, CancellationToken cancellationToken)
    {
        var currentSinger = await _query.SingerQuery().GetAsync(x => x.Id.Equals(Guid.Parse(request.SingerId)) && x.IsActive);
        if (currentSinger == null) return new DataResult<UpdateSingerResponse>("Singer not found!", false);

        UpdateSingerValidator validator = new();
        var validationResult = validator.Validate(request);
        List<string> errors = new();

        validationResult.Errors.ForEach(error => errors.Add(error.ErrorMessage));
        if (!validationResult.IsValid) return new DataResult<UpdateSingerResponse>(errors, false);

        currentSinger.SingerName = request.SingerName == default ? currentSinger.SingerName : request.SingerName;
        currentSinger.MusicStyle = request.MusicStyle == default ? currentSinger.MusicStyle : request.MusicStyle;
        currentSinger.SingerType = request.SingerType == default ? currentSinger.SingerType : request.SingerType;
        currentSinger.SingerPhoto = request.SingerPhoto == default ? currentSinger.SingerPhoto : request.SingerPhoto;
        currentSinger.SingerAbout = request.SingerAbout == default ? currentSinger.SingerAbout : request.SingerAbout;
        currentSinger.Location = request.Location == default ? currentSinger.Location : request.Location;
        currentSinger.UpdatedDate = DateTime.Now;
        currentSinger.UpdatedBy = "System";

        _command.SingerCommand().Edit(currentSinger);
        await _command.SaveAsync();
        return new DataResult<UpdateSingerResponse>(_mapper.Map<UpdateSingerResponse>(currentSinger), "Singer was updated.");

    }
}


using SingerSong.Application.Features.Commands.SingerCommands.InsertAlbum.Models;
using SingerSong.Application.Features.Commands.SingerCommands.InsertAlbum.Validation;

namespace SingerSong.Application.Features.Commands.SingerCommands.InsertAlbum.Handler;

public sealed class InsertAlbumHandler : IRequestHandler<InsertAlbumRequest, IDataResult<InsertAlbumResponse>>
{
    private readonly IUnitOfWorkCommand _command;
    private readonly IUnitOfWorkQuery _query;
    private readonly IMapper _mapper;
    public InsertAlbumHandler(IUnitOfWorkCommand command, IMapper mapper, IUnitOfWorkQuery query)
    {
        _command = command;
        _mapper = mapper;
        _query = query;
    }

    public async Task<IDataResult<InsertAlbumResponse>> Handle(InsertAlbumRequest request, CancellationToken cancellationToken)
    {
        Singer singer = await _query.SingerQuery().GetAsync(x => x.Id == Guid.Parse(request.SingerID));
        if (singer == null)
        {
            return new DataResult<InsertAlbumResponse>("Singer not found!",false);
        }

        InsertAlbumValidator validator = new();
        var validationResult = validator.Validate(request);
        List<string> errors = new();
        if(!validationResult.IsValid)
        {
            validationResult.Errors.ForEach(error => errors.Add(error.ErrorMessage));
            return new DataResult<InsertAlbumResponse>(errors,false);
        }
        Album album = _mapper.Map<Album>(request);
        _command.AlbumCommand().Insert(album);
        await _command.SaveAsync();
        return new DataResult<InsertAlbumResponse>(_mapper.Map<InsertAlbumResponse>(album), $"The album was added to the {singer.Id} Singer");
        
    }

}


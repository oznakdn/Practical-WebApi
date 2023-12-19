using SingerSong.Application.Features.Commands.AlbumCommands.InsertAlbums.Models;
using SingerSong.Application.Features.Commands.AlbumCommands.InsertAlbums.Validation;

namespace SingerSong.Application.Features.Commands.AlbumCommands.InsertAlbums.Handler;

public sealed class InsertAlbumsHandler : IRequestHandler<InsertAlbumsRequest, IDataResult<InsertAlbumsResponse>>
{
    private readonly IUnitOfWorkCommand _command;
    private readonly IUnitOfWorkQuery _query;
    private readonly IMapper _mapper;
    InsertAlbumsValidator validatorSingerId;
    List<string> errors;

    public InsertAlbumsHandler(IUnitOfWorkCommand command, IUnitOfWorkQuery query, IMapper mapper)
    {
        _command = command;
        _query = query;
        _mapper = mapper;
        validatorSingerId = new();
        errors = new();
    }

    public async Task<IDataResult<InsertAlbumsResponse>> Handle(InsertAlbumsRequest request, CancellationToken cancellationToken)
    {

        var idValidationResult = validatorSingerId.Validate(request);
        if (!idValidationResult.IsValid)
        {
            idValidationResult.Errors.ForEach(error => errors.Add(error.ErrorMessage));
            return new DataResult<InsertAlbumsResponse>(errors, false);
        }
        Singer singer = await _query.SingerQuery().GetAsync(x => x.Id.Equals(Guid.Parse(request.SingerId)));
        if (singer == null) return new DataResult<InsertAlbumsResponse>("Singer not found!", false);


        foreach (var album in request.albums)
        {
            singer.Albums.Add(_mapper.Map<Album>(album));
            await _command.SaveAsync();
        }

        return new DataResult<InsertAlbumsResponse>(_mapper.Map<IEnumerable<InsertAlbumsResponse>>(singer.Albums));


    }
}


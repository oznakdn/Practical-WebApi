using SingerSong.Application.Features.Commands.SingerCommands.InsertAlbumSong.Models;
using SingerSong.Application.Features.Commands.SingerCommands.InsertAlbumSong.Validation;

namespace SingerSong.Application.Features.Commands.SingerCommands.InsertAlbumSong.Handler;

public sealed class InsertAlbumSongHandler : IRequestHandler<InsertAlbumSongRequest, IDataResult<InsertAlbumSongResponse>>
{
    private readonly IUnitOfWorkQuery _query;
    private readonly IUnitOfWorkCommand _command;


    public InsertAlbumSongHandler(IUnitOfWorkQuery query, IUnitOfWorkCommand command)
    {
        _query = query;
        _command = command;
    }

    public async Task<IDataResult<InsertAlbumSongResponse>> Handle(InsertAlbumSongRequest request, CancellationToken cancellationToken)
    {
        var singer = await _query.SingerQuery().GetAsync(x => x.Id.Equals(Guid.Parse(request.SingerId)), x => x.Albums);
        if (singer == null)
        {
            return new DataResult<InsertAlbumSongResponse>("Singer not found!", false);
        }

        var album = singer.Albums.SingleOrDefault(x => x.Id.Equals(Guid.Parse(request.AlbumId)));
        if (album == null)
        {
            return new DataResult<InsertAlbumSongResponse>("Album not found!", false);
        }

        InsertAlbumSongValidator validator = new();
        List<string> errors = new();
        var validationResult = validator.Validate(request);

        if (validationResult.IsValid)
        {
            album.Songs.Add(new Song
            {
                SongName = request.SongName,
                SongWeight = request.SongWeight
            });

            await _command.SaveAsync();
            return new DataResult<InsertAlbumSongResponse>("Song was added in the singer's album.", true);
        }

        validationResult.Errors.ForEach(error=> errors.Add(error.ErrorMessage));
        return new DataResult<InsertAlbumSongResponse>(errors, false);

    }
}


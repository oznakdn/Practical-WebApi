using SingerSong.Application.Features.Commands.SingerCommands.InserAlbumSongs.Models;
using SingerSong.Application.Features.Commands.SingerCommands.InserAlbumSongs.Validation;

namespace SingerSong.Application.Features.Commands.SingerCommands.InserAlbumSongs.Handler;

public sealed class InserAlbumSongsHandler : IRequestHandler<InserAlbumSongsRequest, IDataResult<InserAlbumSongsResponse>>
{
    private readonly IUnitOfWorkQuery _query;
    private readonly IUnitOfWorkCommand _command;

    public InserAlbumSongsHandler(IUnitOfWorkQuery query, IUnitOfWorkCommand command)
    {
        _query = query;
        _command = command;
    }

    public async Task<IDataResult<InserAlbumSongsResponse>> Handle(InserAlbumSongsRequest request, CancellationToken cancellationToken)
    {
        var singer = await _query.SingerQuery().GetAsync(x => x.Id.Equals(Guid.Parse(request.SingerId)), x => x.Albums);
        if (singer == null) return new DataResult<InserAlbumSongsResponse>("Singer not found!", false);

        var album = singer.Albums.SingleOrDefault(x => x.Id.Equals(Guid.Parse(request.AlbumId)));
        if (album == null) return new DataResult<InserAlbumSongsResponse>("Singer's album not found!", false);

        InserAlbumSongsValidator validator = new();
        List<string> errors = new();
        var validationResult = validator.Validate(request);

        if (validationResult.IsValid)
        {
            foreach (var song in request.songs)
            {
                album.Songs.Add(new Song
                {
                    SongName = song.SongName,
                    SongWeight = song.SongWeight
                });

                await _command.SaveAsync();
            }
            return new DataResult<InserAlbumSongsResponse>("Songs have been added in the singer's album.", true);
        }

        validationResult.Errors.ForEach(error => errors.Add(error.ErrorMessage));
        return new DataResult<InserAlbumSongsResponse>(errors,false);
    }
}


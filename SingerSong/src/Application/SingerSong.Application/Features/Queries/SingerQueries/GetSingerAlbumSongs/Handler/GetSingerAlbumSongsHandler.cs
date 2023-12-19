using SingerSong.Application.Features.Queries.SingerQueries.GetSingerAlbumSongs.Models;
using SingerSong.Application.Features.Queries.SingerQueries.GetSingerAlbumSongs.Validation;

namespace SingerSong.Application.Features.Queries.SingerQueries.GetSingerAlbumSongs.Handler;

public sealed class GetSingerAlbumSongsHandler : IRequestHandler<GetSingerAlbumSongsRequest, IDataResult<GetSingerAlbumSongsResponse>>
{
    private readonly IUnitOfWorkQuery _query;
    private readonly IMapper _mapper;

    public GetSingerAlbumSongsHandler(IUnitOfWorkQuery query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<IDataResult<GetSingerAlbumSongsResponse>> Handle(GetSingerAlbumSongsRequest request, CancellationToken cancellationToken)
    {
        GetSingerAlbumSongsValidator validator = new();
        var validationResult = validator.Validate(request);
        List<string> errors = new();
        validationResult.Errors.ForEach(error => errors.Add(error.ErrorMessage));
        if (!validationResult.IsValid) return new DataResult<GetSingerAlbumSongsResponse>(errors, false);

        var singerAlbumSong = await _query.SingerQuery().GetSingerAlbumSongs(request.SingerId);
        if (singerAlbumSong == null) return new DataResult<GetSingerAlbumSongsResponse>("There is no singer album's songs", false);
        if (singerAlbumSong.Albums == null) return new DataResult<GetSingerAlbumSongsResponse>("There is no singer's album", false);


        return new DataResult<GetSingerAlbumSongsResponse>(_mapper.Map<GetSingerAlbumSongsResponse>(singerAlbumSong));
    }
}


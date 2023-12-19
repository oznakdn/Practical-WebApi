using SingerSong.Application.Features.Queries.SingerQueries.GetSingerAlbums.Models;
using SingerSong.Application.Features.Queries.SingerQueries.GetSingerAlbums.Validation;

namespace SingerSong.Application.Features.Queries.SingerQueries.GetSingerAlbums.Handler;

public sealed class GetSingerAlbumsHandler : IRequestHandler<GetSingerAlbumsRequest, IDataResult<GetSingerAlbumsResponse>>
{
    private readonly IUnitOfWorkQuery _query;
    private readonly IMapper _mapper;
    public GetSingerAlbumsHandler(IUnitOfWorkQuery query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<IDataResult<GetSingerAlbumsResponse>> Handle(GetSingerAlbumsRequest request, CancellationToken cancellationToken)
    {
        GetSingerAlbumsValidator validator = new();
        var validationResult = validator.Validate(request);
        List<string> errors = new();
        if(!validationResult.IsValid)
        {
            validationResult.Errors.ForEach(error => errors.Add(error.ErrorMessage));
            return new DataResult<GetSingerAlbumsResponse>(errors, false);
        }

        var singerAlbums = await _query.SingerQuery().GetAsync(x => x.Id == Guid.Parse(request.SingerId), x => x.Albums);
        if (singerAlbums == null)
        {
            return new DataResult<GetSingerAlbumsResponse>("There is no singer's albums", false);
        }

        //var result = new GetSingerAlbumsResponse()
        //{
        //    SingerID = singerAlbums.Id.ToString(),
        //    SingerName = singerAlbums.SingerName,
        //    Albums = singerAlbums.Albums.Select(x=> new AlbumResponse
        //    {
        //        AlbumName = x.AlbumName,
        //        CoverPhoto = x.CoverPhoto,
        //        SongCount = x.SongCount
        //    }).ToList()
        //};

       // return new DataResult<GetSingerAlbumsResponse>(result);

        return new DataResult<GetSingerAlbumsResponse>(_mapper.Map<GetSingerAlbumsResponse>(singerAlbums));
    }
}


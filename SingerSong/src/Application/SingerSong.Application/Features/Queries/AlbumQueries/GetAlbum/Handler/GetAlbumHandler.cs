using SingerSong.Application.Features.Queries.AlbumQueries.GetAlbum.Models;

namespace SingerSong.Application.Features.Queries.AlbumQueries.GetAlbum.Handler;

public sealed class GetAlbumHandler : IRequestHandler<GetAlbumRequest, IDataResult<GetAlbumResponse>>
{
    private readonly IUnitOfWorkQuery _query;
    private readonly IMapper _mapper;

    public GetAlbumHandler(IUnitOfWorkQuery query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<IDataResult<GetAlbumResponse>> Handle(GetAlbumRequest request, CancellationToken cancellationToken)
    {
        IQueryable<Album> queryable = await _query.AlbumQuery().GetAllQueryableAsync();

        if (!string.IsNullOrEmpty(request.AlbumName))
        {
            queryable = queryable.Include(x => x.Singer).Where(x => x.AlbumName.ToLower().Contains(request.AlbumName.ToLower()));
            var result = await queryable.ToListAsync(cancellationToken);
            return new DataResult<GetAlbumResponse>(_mapper.Map<IEnumerable<GetAlbumResponse>>(result));
        }

        if (!string.IsNullOrEmpty(request.SingerName))
        {
            queryable = queryable.Include(x => x.Singer).Where(x => x.Singer.SingerName.ToLower().Contains(request.SingerName.ToLower()));
            var album = await queryable.ToListAsync(cancellationToken);
            return new DataResult<GetAlbumResponse>(_mapper.Map<IEnumerable<GetAlbumResponse>>(album));
        }

        return new DataResult<GetAlbumResponse>(_mapper.Map<IEnumerable<GetAlbumResponse>>(await queryable.Include(x => x.Singer).ToListAsync(cancellationToken)));

    }
}


using SingerSong.Application.Features.Queries.SingerQueries.GetSingers.Models;

namespace SingerSong.Application.Features.Queries.SingerQueries.GetSingers.Handler;

public sealed class GetSingersHandler : IRequestHandler<GetSingersRequest, IDataResult<GetSingersResponse>>
{
    private readonly IUnitOfWorkQuery _query;
    private readonly IMapper _mapper;

    public GetSingersHandler(IUnitOfWorkQuery query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<IDataResult<GetSingersResponse>> Handle(GetSingersRequest request, CancellationToken cancellationToken)
    {
        IQueryable<Singer> singers = await _query.SingerQuery().GetAllQueryableAsync();

        if (!string.IsNullOrEmpty(request.SingerName)) singers = singers.Where(x => x.SingerName.ToLower().Contains(request.SingerName.ToLower()));

        await singers.ToListAsync(cancellationToken);
        return new DataResult<GetSingersResponse>(_mapper.Map<IEnumerable<GetSingersResponse>>(singers));
    }

}


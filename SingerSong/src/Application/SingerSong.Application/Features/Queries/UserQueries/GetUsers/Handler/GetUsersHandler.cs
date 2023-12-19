using SingerSong.Application.Features.Queries.UserQueries.GetUsers.Models;

namespace SingerSong.Application.Features.Queries.UserQueries.GetUsers.Handler;

public class GetUsersHandler : IRequestHandler<GetUsersRequest, IDataResult<GetUsersResponse>>
{
    private readonly IUnitOfWorkQuery _query;
    private readonly IMapper _mapper;

    public GetUsersHandler(IUnitOfWorkQuery query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<IDataResult<GetUsersResponse>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
    {
        var users = await _query.UserQuery().GetAllAsync(null, x => x.Role);
        if (users == null) return new DataResult<GetUsersResponse>("There is no user any!", false);

        return new DataResult<GetUsersResponse>(_mapper.Map<IEnumerable<GetUsersResponse>>(users));
    }
}


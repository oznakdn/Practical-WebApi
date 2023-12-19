using SingerSong.Application.Features.Queries.RoleQueries.GetRoles.Models;

namespace SingerSong.Application.Features.Queries.RoleQueries.GetRoles.Handler;

public sealed class GetRolesHandler : IRequestHandler<GetRolesRequest, IDataResult<GetRolesResponse>>
{
    private readonly IUnitOfWorkQuery _query;
    private readonly IMapper _mapper;

    public GetRolesHandler(IUnitOfWorkQuery query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<IDataResult<GetRolesResponse>> Handle(GetRolesRequest request, CancellationToken cancellationToken)
    {
        var roles = await _query.RoleQuery().GetAllAsync();
        return new DataResult<GetRolesResponse>(_mapper.Map<IEnumerable<GetRolesResponse>>(roles));
    }
}


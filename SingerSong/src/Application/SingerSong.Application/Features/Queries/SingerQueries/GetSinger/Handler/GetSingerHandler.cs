using SingerSong.Application.Features.Queries.SingerQueries.GetSinger.Models;
using SingerSong.Application.Features.Queries.SingerQueries.GetSinger.Validation;

namespace SingerSong.Application.Features.Queries.SingerQueries.GetSinger.Handler;

public sealed class GetSingerHandler : IRequestHandler<GetSingerRequest, IDataResult<GetSingerResponse>>
{
    private readonly IUnitOfWorkQuery _query;
    private readonly IMapper _mapper;
    public GetSingerHandler(IUnitOfWorkQuery query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<IDataResult<GetSingerResponse>> Handle(GetSingerRequest request, CancellationToken cancellationToken)
    {

        GetSingerValidator validator = new();
        var validationResult = validator.Validate(request);
        List<string> errors = new();
        if (!validationResult.IsValid)
        {
            validationResult.Errors.ForEach(error => errors.Add(error.ErrorMessage));
            return new DataResult<GetSingerResponse>(errors, false);
        }

        var singer = await _query.SingerQuery().GetAsync(x => x.Id.Equals(Guid.Parse(request.singerId)));
        if (singer == null)
        {
            return new DataResult<GetSingerResponse>("Singer not found!", false);
        }

        return new DataResult<GetSingerResponse>(_mapper.Map<GetSingerResponse>(singer));
    }
}


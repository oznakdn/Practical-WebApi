namespace SingerSong.Application.Features.Queries.SingerQueries.GetSingers.Models;

public record GetSingersRequest(string? SingerName) : IRequest<IDataResult<GetSingersResponse>>;



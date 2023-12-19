namespace SingerSong.Application.Features.Queries.SingerQueries.GetSingerAlbums.Models;

public record GetSingerAlbumsRequest(string SingerId) : IRequest<IDataResult<GetSingerAlbumsResponse>>;



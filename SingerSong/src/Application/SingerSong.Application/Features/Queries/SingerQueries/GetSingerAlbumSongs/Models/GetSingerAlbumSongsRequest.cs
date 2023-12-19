namespace SingerSong.Application.Features.Queries.SingerQueries.GetSingerAlbumSongs.Models;

public record GetSingerAlbumSongsRequest(string SingerId) : IRequest<IDataResult<GetSingerAlbumSongsResponse>>;



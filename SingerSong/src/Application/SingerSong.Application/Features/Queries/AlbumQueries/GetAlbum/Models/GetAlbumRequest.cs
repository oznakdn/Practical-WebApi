namespace SingerSong.Application.Features.Queries.AlbumQueries.GetAlbum.Models;

public record GetAlbumRequest(string? SingerName, string? AlbumName) : IRequest<IDataResult<GetAlbumResponse>>;




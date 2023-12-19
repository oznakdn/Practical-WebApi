namespace SingerSong.Application.Features.Commands.AlbumCommands.InsertAlbums.Models;

public record InsertAlbumsRequest(string SingerId, IEnumerable<InsertAlbum> albums) : IRequest<IDataResult<InsertAlbumsResponse>>;

public record InsertAlbum(string AlbumName, int SongCount, string CoverPhoto);
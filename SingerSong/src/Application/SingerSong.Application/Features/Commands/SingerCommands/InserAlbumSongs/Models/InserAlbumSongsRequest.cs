using MediatR;
using SingerSong.Core.Abstracts.Result;

namespace SingerSong.Application.Features.Commands.SingerCommands.InserAlbumSongs.Models;

public record class InserAlbumSongsRequest(string SingerId, string AlbumId, IEnumerable<SongRequest> songs) : IRequest<IDataResult<InserAlbumSongsResponse>>;
public record SongRequest(string SongName, float SongWeight);
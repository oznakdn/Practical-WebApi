using MediatR;
using SingerSong.Core.Abstracts.Result;

namespace SingerSong.Application.Features.Commands.SingerCommands.InsertAlbumSong.Models;
public record InsertAlbumSongRequest(string SingerId, string AlbumId, string SongName, float SongWeight) : IRequest<IDataResult<InsertAlbumSongResponse>>;



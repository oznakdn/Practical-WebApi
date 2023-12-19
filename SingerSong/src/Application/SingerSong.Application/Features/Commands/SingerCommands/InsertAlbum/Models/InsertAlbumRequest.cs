using MediatR;
using SingerSong.Core.Abstracts.Result;

namespace SingerSong.Application.Features.Commands.SingerCommands.InsertAlbum.Models;

public record InsertAlbumRequest(string AlbumName,string CoverPhoto, int SongCount, string SingerID) : IRequest<IDataResult<InsertAlbumResponse>>;



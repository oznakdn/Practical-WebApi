using MediatR;
using SingerSong.Core.Abstracts.Result;

namespace SingerSong.Application.Features.Queries.SingerQueries.GetSinger.Models;

public record GetSingerRequest(string singerId) : IRequest<IDataResult<GetSingerResponse>>;



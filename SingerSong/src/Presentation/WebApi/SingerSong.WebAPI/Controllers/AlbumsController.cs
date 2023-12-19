using Microsoft.AspNetCore.Authorization;
using SingerSong.Application.Features.Commands.AlbumCommands.InsertAlbums.Models;
using SingerSong.Application.Features.Queries.AlbumQueries.GetAlbum.Models;

namespace SingerSong.WebAPI.Controllers;

//[Authorize]
[Route("api/[controller]")]
[ApiController]
public class AlbumsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AlbumsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAlbum(string? SingerName, string? AlbumName)
    {
        var result = await _mediator.Send(new GetAlbumRequest(SingerName, AlbumName));
        if (!result.IsSuccess) return NotFound(result.Message);
        if (result.DataValues != null) return Ok(result.DataValues);
        return Ok(result.DataValue);
    }

    [HttpPost]
    public async Task<IActionResult> InsertAlbums([FromBody] InsertAlbumsRequest insertAlbums)
    {
        var result = await _mediator.Send(insertAlbums);
        if (result.Messages != null) return BadRequest(result.Messages);
        if (result.Message != null) return NotFound(result.Message);
        return Created("", result.DataValues);
    }
}


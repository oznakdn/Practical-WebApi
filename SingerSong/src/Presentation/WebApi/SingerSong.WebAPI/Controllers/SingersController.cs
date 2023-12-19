namespace SingerSong.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SingersController : ControllerBase
{
    private readonly IMediator _mediator;

    public SingersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Singers(string? SingerName)
    {
        var result = await _mediator.Send(new GetSingersRequest(SingerName));
        return Ok(result.DataValues);
    }

    [HttpGet("Singer/{SingerId}")]
    public async Task<IActionResult> Singer(string SingerId)
    {
        var result = await _mediator.Send(new GetSingerRequest(SingerId));
        if (result.Messages != null) return BadRequest(result.Messages);
        if (!result.IsSuccess) return NotFound(result.Message);
        return Ok(result.DataValue);
    }

    [HttpGet("Albums/{SingerId}")]
    public async Task<IActionResult> GetSingerAlbums(string SingerId)
    {
        var result = await _mediator.Send(new GetSingerAlbumsRequest(SingerId));
        if (result.Messages != null) return BadRequest(result.Messages);
        if (!result.IsSuccess) return NotFound(result.Message);
        return Ok(new { Data = result.DataValue });
    }

    [HttpGet("Album/Songs/{SingerId}")]
    public async Task<IActionResult> GetSingerAlbumSongs(string SingerId)
    {
        var result = await _mediator.Send(new GetSingerAlbumSongsRequest(SingerId));
        if (result.Messages != null) return BadRequest(result.Messages);
        if (!result.IsSuccess) return NotFound(result.Message);
        return Ok(new { Data = result.DataValue });
    }

    [HttpPost]
    public async Task<IActionResult> InsertSinger([FromBody] InsertSingerRequest insertSinger)
    {
        var result = await _mediator.Send(insertSinger);
        if (!result.IsSuccess) return BadRequest(result.Messages);
        return Created("", new { Data = result.DataValue, Message = result.Message });
    }

    [HttpPost("InsertAlbum")]
    public async Task<IActionResult> InsertSingerAlbum([FromBody] InsertAlbumRequest insertAlbum)
    {
        var result = await _mediator.Send(insertAlbum);
        if (result.DataValue == null) return NotFound(result.Messages);

        if (!result.IsSuccess) return BadRequest(result.Messages);
        return Created("", new { Data = result.DataValue, Message = result.Message });
    }

    [HttpPost("InsertAlbumSong")]
    public async Task<IActionResult> InsertSingerAlbumSong([FromBody] InsertAlbumSongRequest insertAlbumSong)
    {
        var result = await _mediator.Send(insertAlbumSong);
        if (!result.IsSuccess) return NotFound(result.Messages);
        if (result.Messages != null) return BadRequest(result.Messages);
        return Created("", result.Message);
    }

    [HttpPost("InsertAlbumSongs")]
    public async Task<IActionResult> InsertSingerAlbumSongs([FromBody] InserAlbumSongsRequest inserAlbumSongs)
    {
        var result = await _mediator.Send(inserAlbumSongs);
        if (!result.IsSuccess) return NotFound(result.Message);
        if (result.Messages != null) return BadRequest(result.Messages);
        return Created("", result.Message);
    }

    [HttpDelete("{SingerId}")]
    public async Task<IActionResult> RemoveSinger(string SingerId)
    {
        var result = await _mediator.Send(new RemoveSingerRequest(singerId: SingerId));
        if (result.Messages != null) return BadRequest(result.Messages);
        if (!result.IsSuccess) return NotFound(result.Message);
        return Ok(result.Message);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSinger([FromBody] UpdateSingerRequest updateSinger)
    {
        var result = await _mediator.Send(updateSinger);
        if (result.Messages != null) return BadRequest(result.Messages);
        if (!result.IsSuccess) return NotFound(result.Message);
        return Ok(new { Data = result.DataValue, Message = result.Message });
    }

}


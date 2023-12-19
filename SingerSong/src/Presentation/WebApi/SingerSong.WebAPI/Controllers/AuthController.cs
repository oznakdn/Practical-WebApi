using SingerSong.Application.Features.Commands.UserCommands.UserLogin.Models;
using SingerSong.Application.Features.Commands.UserCommands.UserRegister.Models;

namespace SingerSong.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> UserLogin([FromBody] UserLoginRequest userLogin)
    {
        var result = await _mediator.Send(userLogin);
        if (result.Messages != null) return BadRequest(result.Messages);
        if (result.Message != null) return NotFound(result.Message);
        return Ok(result.DataValue);
    }

    [HttpPost("Register")]
    public async Task<IActionResult> UserRegister([FromBody] UserRegisterRequest userRegister)
    {
        var result = await _mediator.Send(userRegister);
        if (result.Messages != null) return BadRequest(result.Messages);
        if (result.Message != null && !result.IsSuccess) return NotFound(result.Message);
        return Created("", result.Message);
    }
}


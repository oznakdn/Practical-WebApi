using Microsoft.AspNetCore.Authorization;
using SingerSong.Application.Features.Commands.RoleCommands.InsertRole.Models;
using SingerSong.Application.Features.Queries.RoleQueries.GetRoles.Models;
using SingerSong.Application.Features.Queries.UserQueries.GetUsers.Models;

namespace SingerSong.WebAPI.Controllers;


//[Authorize(Roles = "Admin,Manager")]
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("User")]
    public async Task<IActionResult> Users()
    {
        var result = await _mediator.Send(new GetUsersRequest());
        if (!result.IsSuccess) return NotFound(result.Message);
        return Ok(result.DataValues);
    }

    [HttpPost("Role")]
    public async Task<IActionResult> Insert([FromBody] InsertRoleRequest insertRole)
    {
        var result = await _mediator.Send(insertRole);
        if (result.IsSuccess) return Created("", new { Data = result.DataValue, Message = result.Message });
        if (result.Messages != null) return BadRequest(result.Messages);
        return BadRequest(result.Message);
    }

    [HttpGet("Role")]
    public async Task<IActionResult>Roles()
    {
        var result = await _mediator.Send(new GetRolesRequest());
        return Ok(result.DataValues);
    }
}


namespace SingerSong.Application.Features.Queries.RoleQueries.GetRoles.Models;

public record GetRolesResponse
{
    public string RoleId { get; set; }
    public string RoleTitle { get; set; }
    public string Description { get; set; }
}


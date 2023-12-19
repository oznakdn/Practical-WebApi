namespace SingerSong.Application.Features.Commands.RoleCommands.InsertRole.Models;
public record InsertRoleRequest(string RoleTitle, string Description) : IRequest<IDataResult<InsertRoleResponse>>;


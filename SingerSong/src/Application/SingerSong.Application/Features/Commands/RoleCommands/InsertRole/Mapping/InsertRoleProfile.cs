using SingerSong.Application.Features.Commands.RoleCommands.InsertRole.Models;
using SingerSong.Domain.Identities;

namespace SingerSong.Application.Features.Commands.RoleCommands.InsertRole.Mapping;
internal class InsertRoleProfile : Profile
{
    public InsertRoleProfile()
    {
        CreateMap<InsertRoleRequest, Role>();
        CreateMap<Role, InsertRoleResponse>();
    }
}


using SingerSong.Application.Features.Queries.RoleQueries.GetRoles.Models;
using SingerSong.Domain.Identities;

namespace SingerSong.Application.Features.Queries.RoleQueries.GetRoles.Mapping;

internal class GetRolesProfile : Profile
{
    public GetRolesProfile()
    {
        CreateMap<Role, GetRolesResponse>()
            .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Id.ToString()));
    }
}


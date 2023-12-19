using SingerSong.Application.Features.Queries.UserQueries.GetUsers.Models;
using SingerSong.Domain.Identities;

namespace SingerSong.Application.Features.Queries.UserQueries.GetUsers.Mapping;

internal class GetUsersProfile : Profile
{
    public GetUsersProfile()
    {
        CreateMap<User,GetUsersResponse>()
            .ForMember(dest=> dest.Id,opt=> opt.MapFrom(src=>src.Id.ToString()))
            .ForMember(dest=>dest.Role,opt=> opt.MapFrom(src=>src.Role.RoleTitle));
    }
}


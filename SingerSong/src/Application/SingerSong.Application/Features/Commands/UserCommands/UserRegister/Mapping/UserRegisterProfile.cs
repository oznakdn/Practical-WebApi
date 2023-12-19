using SingerSong.Application.Features.Commands.UserCommands.UserRegister.Models;
using SingerSong.Domain.Identities;

namespace SingerSong.Application.Features.Commands.UserCommands.UserRegister.Mapping;

internal class UserRegisterProfile : Profile
{
    public UserRegisterProfile()
    {
        CreateMap<UserRegisterRequest, User>().ReverseMap();
    }
}


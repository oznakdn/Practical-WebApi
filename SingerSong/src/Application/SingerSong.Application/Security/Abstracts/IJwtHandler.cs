using SingerSong.Domain.Identities;

namespace SingerSong.Application.Security.Abstracts;

public interface IJwtHandler
{
    ITokenResponse GenerateAccessToken(User user, int expiredTime);
    string GenerateRefreshToken();
}



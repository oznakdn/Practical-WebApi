using SingerSong.Application.Security.Abstracts;

namespace SingerSong.Application.Security.Concretes;

public record TokenResponse : ITokenResponse
{
    public string AccessToken { get ; init ; }
    public string RefreshToken { get ; init; }
    public DateTime ExpiredTime { get ; init ; }
}


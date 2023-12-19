namespace SingerSong.Application.Security.Abstracts;

public interface ITokenResponse
{
    string AccessToken { get; init; }
    string RefreshToken { get; init; }
    DateTime ExpiredTime { get; init; }

}


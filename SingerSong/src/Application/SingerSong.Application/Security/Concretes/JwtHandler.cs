using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SingerSong.Application.Security.Abstracts;
using SingerSong.Domain.Identities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SingerSong.Application.Security.Concretes;

public class JwtHandler : IJwtHandler
{
    private readonly JwtSettings _jwtSettings;
    public JwtHandler(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }
    public ITokenResponse GenerateAccessToken(User user, int expiredTime)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        var claims = new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            //new Claim(ClaimTypes.Role, user.Role.RoleTitle)
        };


        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Audience = _jwtSettings.Audience,
            Issuer = _jwtSettings.Issuer,
            Expires = DateTime.Now.AddMinutes(expiredTime),
            SigningCredentials = signingCredentials,
            Subject = new ClaimsIdentity(claims)
        };


        SecurityTokenHandler securityToken = new JwtSecurityTokenHandler();
        SecurityToken token = securityToken.CreateToken(tokenDescriptor);
        string accessToken = securityToken.WriteToken(token);


        return new TokenResponse
        {
            AccessToken = accessToken,
            RefreshToken = GenerateRefreshToken(),
            ExpiredTime = DateTime.Now.AddMinutes(expiredTime + 3),
        };

    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}


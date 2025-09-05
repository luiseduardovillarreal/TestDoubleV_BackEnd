using I_AM.Domain.Services;
using I_AM.Infrastructure.Commons;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace I_AM.Infrastructure.Services;

#pragma warning disable CS8600
#pragma warning disable CS8604

public class AuthService(IConfiguration configuration) : IAuthService
{
    private readonly IConfiguration _configuration = configuration;

    public string GetToken(Guid uuId)
        => GenerateToken(uuId);

    public string GetTokenInquest()
        => GenerateTokenInquest();

    public string GetTokenForgotPassword()
        => GenerateTokenForgotPassword();

    public string RefreshToken(Guid uuId) 
        => GenerateToken(uuId);

    private string GenerateToken(Guid idUser)
    {
        string keySecret = _configuration[Constants.Services.AuthService.KEY_SECRET];
        string jwtIssuer = _configuration[Constants.Services.AuthService.ISSUER];
        string jwtAudience = _configuration[Constants.Services.AuthService.AUDIENCE];
        string minutActive = _configuration[Constants.Services.AuthService.MINUTES_ACTIVE];

        string base64SecretKey = Convert.ToBase64String(Encoding.UTF8.GetBytes(keySecret));
        byte[] secretKeyBytes = Convert.FromBase64String(base64SecretKey);
        JwtSecurityTokenHandler tokenHandler = new();

        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, idUser.ToString()),
            }),
            Issuer = jwtIssuer,
            Audience = jwtAudience,
            Expires = DateTime.Now.AddMinutes(double.Parse(minutActive)),
            NotBefore = DateTime.Now,
            SigningCredentials = new(
                new SymmetricSecurityKey(secretKeyBytes),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private string GenerateTokenInquest()
    {
        var byteArray = new byte[64];
        var token = string.Empty;

        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(byteArray);
            token = Convert.ToBase64String(byteArray);
        }
        return token;
    }

    private string GenerateTokenForgotPassword()
    {
        var byteArray = new byte[64];
        var token = string.Empty;

        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(byteArray);
            token = Convert.ToBase64String(byteArray);
        }
        return token;
    }
}
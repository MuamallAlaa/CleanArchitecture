using System.Security.Claims;
using System.Text;
using CleanArchitecture.Application.Common.interfaces.Authentication;
using CleanArchitecture.Application.Common.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace CleanArchitecture.Infrastructure.Authentication;

public class JwtTokenGenerator(IOptions<JwtSettings> jwtSettings, IDateTimeProvider dateTimeProvider)
    : IJwtTokenGenerator
{
    public string GenerateJwtToken(Guid userId, string firstName, string lastName)
    {
        var secretKey = jwtSettings.Value.SecretKey;
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(CreateClaims(userId)),
            Expires = dateTimeProvider.UtcNow.AddDays(jwtSettings.Value.ExpirationInDays),
            SigningCredentials = credentials,
            Issuer = jwtSettings.Value.Issuer,
            Audience = jwtSettings.Value.Audience
        };

        var handler = new JsonWebTokenHandler();
        var token = handler.CreateToken(tokenDescriptor);
        return token;
    }

    private static Claim[] CreateClaims(Guid userId)
    {
        return 
        [
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString())
        ];
    }
}
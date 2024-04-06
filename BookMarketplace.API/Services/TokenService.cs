using BookMarketplace.Shared.Dtos;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.SymbolStore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookMarketplace.API.Services;

public class TokenService(IConfiguration configuration)
{

    public static TokenValidationParameters GetTokenValidationParameter(IConfiguration configuration) =>
        new()
        {
            ValidateAudience = false,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            IssuerSigningKey = GetSecurityKey(configuration)
        };

    public string GenerateJwt(LoggedInUser user)
    {
        var securityKey = GetSecurityKey(configuration);

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.Aes128CbcHmacSha256);
        int expireMin = int.Parse(configuration["Jwt:ExpireInMinute"]!);

        Claim[] claims = [
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.StreetAddress, user.Address),
            ];

        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: "*",
            claims: claims,
            signingCredentials: credentials,
            expires: DateTime.Now.AddMinutes(expireMin)
            );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }

    private static SymmetricSecurityKey GetSecurityKey(IConfiguration configuration)
    {
        var secreteKey = configuration["Jwt:SecretKey"];
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secreteKey!));
        return securityKey;
    }
}

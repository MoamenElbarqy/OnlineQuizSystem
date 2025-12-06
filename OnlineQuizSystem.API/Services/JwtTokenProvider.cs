using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using OnlineQuizSystem.API.Interfaces;
using OnlineQuizSystem.API.Response;

namespace OnlineQuizSystem.API.Services;

public class JwtTokenProvider: ITokenProvider
{
    private readonly IConfiguration _configuration;
    public JwtTokenProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public TokenResponse GenerateToken(GenerateTokenRequest generateTokenRequest)
    {
        
        var jwtSettings = _configuration.GetSection("JwtSettings");

        var issuer = jwtSettings["Issuer"]!;
        var audience = jwtSettings["Audience"]!;
        var expires = DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["TokenExpirationInMinutes"]!));
        var key = jwtSettings["SecretKey"]!;
        
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, generateTokenRequest.Id.ToString()),
            new Claim(ClaimTypes.Role, generateTokenRequest.Role.ToString())
        };
        var descriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = expires,
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                SecurityAlgorithms.HmacSha256Signature
            )
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(descriptor);
        
        return new TokenResponse
        {
            AceessToken = tokenHandler.WriteToken(securityToken),
            RefreshToken = "7a6f23b4e1d04c9a8f5b6d7c8a9e01f1",
            ExpiresIn = expires
        };
        
    }

    public TokenResponse RefreshToken(RefreshTokenRequest refreshTokenRequest)
    {
        throw new NotImplementedException();
    }
}
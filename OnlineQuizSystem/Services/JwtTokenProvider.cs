using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineQuizSystem.Data;
using OnlineQuizSystem.Interfaces;
using OnlineQuizSystem.Models;
using OnlineQuizSystem.Requests;
using OnlineQuizSystem.Response;

namespace OnlineQuizSystem.Services;

public class JwtTokenProvider : ITokenProvider
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;
    public JwtTokenProvider(IConfiguration configuration, AppDbContext context)
    {
        _configuration = configuration;
        _context = context;
    }

    public  async Task<TokenResponse?> GenerateTokenAsync(GenerateTokenRequest generateTokenRequest)
    {
        
        var jwtSettings = _configuration.GetSection("JwtSettings");

        var issuer = jwtSettings["Issuer"]!;
        var audience = jwtSettings["Audience"]!;
        var expires = DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["TokenExpirationInMinutes"]!));
        var key = jwtSettings["SecretKey"]!;

        var user = await _context.Users.Include(u => u.RefreshTokens).
        FirstOrDefaultAsync(u => u.Id == generateTokenRequest.Id);

        if (user is null)
            return null;

        var existingRefreshToken = user.RefreshTokens.FirstOrDefault(rt => rt.IsActive);

        if (existingRefreshToken is not null)
        {
            existingRefreshToken.RevokedAt = DateTime.UtcNow;
            _context.RefreshTokens.Update(existingRefreshToken);
            await _context.SaveChangesAsync();
        }
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

        string refreshToken = GenerateRefreshToken();


        RefreshToken refreshTokenModel = new RefreshToken
        {
            Id = Guid.NewGuid(),
            UserId = generateTokenRequest.Id,
            Token = refreshToken,
            CreatedAt = DateTime.UtcNow,
            ExpiresAt = DateTime.UtcNow.AddMinutes(5)
        };

        await _context.RefreshTokens.AddAsync(refreshTokenModel);
        await _context.SaveChangesAsync();

        return new TokenResponse
        {
            AccessToken = tokenHandler.WriteToken(securityToken),
            RefreshToken = refreshTokenModel,
            ExpiresIn = expires
        };

    }
    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }
    public async Task<TokenResponse?> RefreshTokenAsync(string refreshToken)
    {
        if(string.IsNullOrEmpty(refreshToken))
            return null;
        
        var existingToken = await _context.RefreshTokens.Include(rt => rt.User)
            .FirstOrDefaultAsync(rt => rt.Token == refreshToken);

        if (existingToken == null || !existingToken.IsActive)
        {
            return null;
        }

        existingToken.RevokedAt = DateTime.UtcNow;
        _context.RefreshTokens.Update(existingToken);
        await _context.SaveChangesAsync();

        return await GenerateTokenAsync (new GenerateTokenRequest
        {
            Id = existingToken.UserId,
            Role = existingToken.User.Role
        });
    }


}
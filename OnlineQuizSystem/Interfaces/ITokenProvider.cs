using OnlineQuizSystem.API.Response;
using OnlineQuizSystem.API.Services;

namespace OnlineQuizSystem.API.Interfaces;

public interface ITokenProvider
{
    public  Task<TokenResponse?> GenerateTokenAsync(GenerateTokenRequest generateTokenRequest);
    public  Task<TokenResponse?> RefreshTokenAsync(string refreshToken);
}
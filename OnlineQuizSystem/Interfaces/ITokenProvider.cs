using OnlineQuizSystem.Response;
using OnlineQuizSystem.Services;


namespace OnlineQuizSystem.Interfaces;

public interface ITokenProvider
{
    public  Task<TokenResponse?> GenerateTokenAsync(GenerateTokenRequest generateTokenRequest);
    public  Task<TokenResponse?> RefreshTokenAsync(string refreshToken);
}
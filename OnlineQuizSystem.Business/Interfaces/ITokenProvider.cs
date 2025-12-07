using OnlineQuizSystem.API.Response;
using OnlineQuizSystem.API.Services;

namespace OnlineQuizSystem.API.Interfaces;

public interface ITokenProvider
{
    public TokenResponse GenerateToken(GenerateTokenRequest generateTokenRequest);
    public TokenResponse RefreshToken(string refreshToken);
}
using OnlineQuizSystem.API.Response;
using OnlineQuizSystem.API.Services;

namespace OnlineQuizSystem.API.Interfaces;

public interface ITokenProvider
{
    public UserTokenResponse GenerateToken(GenerateTokenRequest generateTokenRequest);
    public UserTokenResponse RefreshToken(RefreshTokenRequest refreshTokenRequest);
}
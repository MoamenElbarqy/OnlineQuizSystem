using OnlineQuizSystem.API.Response;
using OnlineQuizSystem.Business.Requests;

namespace OnlineQuizSystem.Business.Interfaces;

public interface ILoginManager
{
    public Task<TokenResponse?> ProcessLoginAsync(UserLoginRequest request);
}
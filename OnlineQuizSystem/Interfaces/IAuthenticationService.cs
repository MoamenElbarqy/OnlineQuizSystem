using OnlineQuizSystem.Business.Requests;
using OnlineQuizSystem.Models;

namespace OnlineQuizSystem.Interfaces;

public interface IAuthService
{
    public Task<User?> AuthenticateAsync(UserLoginRequest request);
}
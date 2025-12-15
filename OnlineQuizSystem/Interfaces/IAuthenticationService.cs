using OnlineQuizSystem.Models;
using OnlineQuizSystem.Requests;

namespace OnlineQuizSystem.Interfaces;

public interface IAuthService
{
    public Task<User?> AuthenticateAsync(UserLoginRequest request);
}
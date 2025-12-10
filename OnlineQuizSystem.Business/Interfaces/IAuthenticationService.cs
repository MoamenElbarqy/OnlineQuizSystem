using OnlineQuizSystem.Business.Requests;
using OnlineQuizSystem.Data.Models;

namespace OnlineQuizSystem.Business.Interfaces;

public interface IAuthService
{
    public Task<User?> AuthenticateAsync(UserLoginRequest request);
}
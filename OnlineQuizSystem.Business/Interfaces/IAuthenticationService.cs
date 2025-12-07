using OnlineQuizSystem.Business.Requests;
using OnlineQuizSystem.Data.Models;

namespace OnlineQuizSystem.Business.Interfaces;

public interface IAuthenticationService
{
    public Task<User?> AuthenticateAsync(UserLoginRequest request);
}
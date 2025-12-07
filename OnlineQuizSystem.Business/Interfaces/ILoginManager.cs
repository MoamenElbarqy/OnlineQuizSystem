using OnlineQuizSystem.Business.Requests;
using OnlineQuizSystem.Data.Models;

namespace OnlineQuizSystem.Business.Interfaces;

public interface ILoginManager
{
    public Task<User?> CheckUserCredentialsAsync(UserLoginRequest request);
}
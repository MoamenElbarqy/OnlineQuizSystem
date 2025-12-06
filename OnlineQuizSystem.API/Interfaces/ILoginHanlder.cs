using Microsoft.AspNetCore.Mvc;
using OnlineQuizSystem.API.Response;
using OnlineQuizSystem.Business.Requests;
using OnlineQuizSystem.Data.Enums;

namespace OnlineQuizSystem.API.LoginHandlers;

public interface ILoginHandler
{
    bool CanHanlde(Role role);
    Task<TokenResponse?> HandleLoginAsync(UserLoginRequest request);
}

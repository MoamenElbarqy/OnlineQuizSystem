using Microsoft.AspNetCore.Mvc;
using OnlineQuizSystem.API.Interfaces;
using OnlineQuizSystem.API.Response;
using OnlineQuizSystem.Business.Requests;
using OnlineQuizSystem.Business.Services;
using OnlineQuizSystem.Data.Enums;

namespace OnlineQuizSystem.API.LoginHandlers;

public class AdminLoginHandler(AdminService adminService, ITokenProvider tokenProvider) : ILoginHandler
{
    public bool CanHanlde(Role role)
    {
        return role == Role.Admin;
    }
    public Task<TokenResponse?> HandleLoginAsync(UserLoginRequest request)
    {
        throw new NotImplementedException();
    }
}
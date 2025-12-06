using Microsoft.AspNetCore.Mvc;
using OnlineQuizSystem.API.Interfaces;
using OnlineQuizSystem.API.Response;
using OnlineQuizSystem.API.Services;
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
    public async Task<UserTokenResponse?> HandleLoginAsync(UserLoginRequest request)
    {
        var admin = adminService.IsExsisted(request);

        if (admin is null)
            return null;

        var gnerateTokenRequest = new GenerateTokenRequest
        {
            Id = admin.Id,
            Role = admin.Role
        };

        var tokenResponse = tokenProvider.GenerateToken(gnerateTokenRequest);
        
        return tokenResponse;
    }
}
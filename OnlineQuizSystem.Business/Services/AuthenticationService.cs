using OnlineQuizSystem.Business.Interfaces;
using OnlineQuizSystem.Business.Requests;
using OnlineQuizSystem.Business.Services;
using OnlineQuizSystem.Data.Models;

namespace OnlineQuizSystem.Business.Managers;

class AuthenticationService : IAuthenticationService
{
    private readonly AdminService _adminService;
    AuthenticationService(AdminService adminService)
    {
        _adminService = adminService;
    }
    public async Task<User?> AuthenticateAsync(UserLoginRequest request)
    {
        var admin = await _adminService.IsExisted(request);

        return null;
    }
}
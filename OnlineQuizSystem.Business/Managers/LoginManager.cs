using OnlineQuizSystem.Business.Interfaces;
using OnlineQuizSystem.Business.Requests;
using OnlineQuizSystem.Business.Services;
using OnlineQuizSystem.Data.Models;

namespace OnlineQuizSystem.Business.Managers;

class LoginManager : ILoginManager
{
    private readonly AdminService _adminService;
    LoginManager(AdminService adminService)
    {
        _adminService = adminService;
    }   
    public async Task<User?> CheckUserCredentialsAsync(UserLoginRequest request)
    {
        var admin = await _adminService.IsExisted(request);
        
        return null;
    }
}
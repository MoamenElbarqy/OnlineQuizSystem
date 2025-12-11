using OnlineQuizSystem.Interfaces;
using OnlineQuizSystem.Business.Requests;
using OnlineQuizSystem.Models;

namespace OnlineQuizSystem.Business.Services;

public class AuthService : IAuthService
{
    private readonly UserService _userService;
    
    AuthService(UserService userService)
    {
        _userService = userService;
    }
    public async Task<User?> AuthenticateAsync(UserLoginRequest request)
    {
        var user = await _userService.IsExistedAsync(request.Email, request.Password);

        return null;
    }
}
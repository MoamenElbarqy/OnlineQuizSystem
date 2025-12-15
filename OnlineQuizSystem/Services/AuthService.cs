using OnlineQuizSystem.Interfaces;
using OnlineQuizSystem.Requests;
using OnlineQuizSystem.Models;

namespace OnlineQuizSystem.Business.Services;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    
    public AuthService(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<User?> AuthenticateAsync(UserLoginRequest request)
    {
        var user = await _userService.FindAsync(request.Email, request.Password);

        return null;
    }
}
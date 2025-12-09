using OnlineQuizSystem.Business.Interfaces;
using OnlineQuizSystem.Business.Requests;
using OnlineQuizSystem.Data.Models;

namespace OnlineQuizSystem.Business.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserService _userService;
    AuthenticationService(UserService userService)
    {
        _userService = userService;
    }
    public async Task<User?> AuthenticateAsync(UserLoginRequest request)
    {
        var user = await _userService.IsExistedAsync(request.Email, request.Password);

        return null;
    }
}
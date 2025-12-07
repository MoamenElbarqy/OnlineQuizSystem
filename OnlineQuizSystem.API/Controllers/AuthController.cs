using Microsoft.AspNetCore.Mvc;
using OnlineQuizSystem.API.Interfaces;
using OnlineQuizSystem.API.Models;
using OnlineQuizSystem.API.Response;
using OnlineQuizSystem.API.Responses;
using OnlineQuizSystem.API.Services;
using OnlineQuizSystem.Business.Interfaces;
using OnlineQuizSystem.Business.Requests;

namespace OnlineQuizSystem.API.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly ILoginManager _LoginManager;
    private readonly ITokenProvider _tokenProvider;
    public AuthController(ILoginManager LoginManager, ITokenProvider tokenProvider)
    {
        _LoginManager = LoginManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginRequest request)
    {
        var user = await _LoginManager.CheckUserCredentialsAsync(request);

        if (user is null)
            return BadRequest("Invalid Data");

        var generateTokenRequest = new GenerateTokenRequest
        {
            Id = user.Id,
            Role = user.Role
        };

        var tokenResponse = _tokenProvider.GenerateToken(generateTokenRequest);

        var UserDto = new UserDto
        {
            Username = user.Name,
            Role = user.Role
        };
        var response = new AuthResponse
        {
            AccessToken = tokenResponse.AceessToken,
            ExpiresAt = tokenResponse.ExpiresIn,
            User = UserDto      
        };
        Response.Cookies.Append("refreshToken", tokenResponse.RefreshToken.Token, new CookieOptions
        {
            HttpOnly = true,         
            Secure = true,           
            SameSite = SameSiteMode.Strict,
            Expires = tokenResponse.RefreshToken.ExpiresAt
        });
        return Ok(response);
    }
    [HttpPost("refresh")]
    public IActionResult Refresh()
    {
        var refreshToken = Request.Cookies["refreshToken"];

        if (string.IsNullOrEmpty(refreshToken))
            return BadRequest("Invalid Data");

        var tokenResponse = _tokenProvider.RefreshToken(refreshToken);

        if (tokenResponse is null)
            return BadRequest("Invalid Data");

        Response.Cookies.Append("refreshToken", tokenResponse.RefreshToken.Token, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = tokenResponse.RefreshToken.ExpiresAt
        });

        return Ok(new
        {
            accessToken = tokenResponse.AceessToken,
            expiresIn = tokenResponse.ExpiresIn
        });
    }

}
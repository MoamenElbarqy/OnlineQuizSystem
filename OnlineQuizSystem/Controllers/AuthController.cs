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
    private readonly IAuthService _LoginManager;
    private readonly ITokenProvider _tokenProvider;
    public AuthController(IAuthService LoginManager, ITokenProvider tokenProvider)
    {
        _LoginManager = LoginManager;
        _tokenProvider = tokenProvider;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginRequest request)
    {
        var user = await _LoginManager.AuthenticateAsync(request);

        if (user is null)
            return BadRequest("Invalid Data");

        var generateTokenRequest = new GenerateTokenRequest
        {
            Id = user.Id,
            Role = user.Role
        };

        var tokenResponse = await _tokenProvider.GenerateTokenAsync(generateTokenRequest);

        if (tokenResponse is null)
            return BadRequest("Invalid Data");

        var UserDto = new UserDto
        {
            Username = user.Name,
            Role = user.Role
        };
        var response = new AuthResponse
        {
            AccessToken = tokenResponse.AccessToken,
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
    public async Task<IActionResult> Refresh()
    {
        var refreshToken = Request.Cookies["refreshToken"];

        if (string.IsNullOrEmpty(refreshToken))
            return BadRequest("Invalid Data");

        var tokenResponse = await _tokenProvider.RefreshTokenAsync(refreshToken);

        if (tokenResponse is null)
            return BadRequest("Invalid Data");

        UserDto UserDto = new UserDto
        {
            Username = tokenResponse.RefreshToken.User.Name,
            Role = tokenResponse.RefreshToken.User.Role
        };
        Response.Cookies.Append("refreshToken", tokenResponse.RefreshToken.Token, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = tokenResponse.RefreshToken.ExpiresAt
        });

        var response = new AuthResponse
        {
            AccessToken = tokenResponse.AccessToken,
            ExpiresAt = tokenResponse.ExpiresIn,
            User = UserDto
        };
        return Ok(response);
    }

}
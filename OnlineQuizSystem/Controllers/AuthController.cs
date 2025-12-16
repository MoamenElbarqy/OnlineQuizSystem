using Microsoft.AspNetCore.Mvc;
using OnlineQuizSystem.Interfaces;
using OnlineQuizSystem.Responses;
using OnlineQuizSystem.Requests;
using OnlineQuizSystem.Data;

namespace OnlineQuizSystem.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _LoginManager;
    private readonly ITokenProvider _TokenProvider;

    public AuthController(IAuthService LoginManager, ITokenProvider tokenProvider)
    {
        _LoginManager = LoginManager;
        _TokenProvider = tokenProvider;
    }

    [HttpPost("login")]
    [ProducesResponseType<AuthResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
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

        var tokenResponse = await _TokenProvider.GenerateTokenAsync(generateTokenRequest);

        if (tokenResponse is null)
            return BadRequest("Invalid Data");

        var UserDto = new UserAuthResponse
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
    [ProducesResponseType<AuthResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Refresh()
    {
        var refreshToken = Request.Cookies["refreshToken"];

        if (string.IsNullOrEmpty(refreshToken))
            return BadRequest("Invalid Data");

        var tokenResponse = await _TokenProvider.RefreshTokenAsync(refreshToken);

        if (tokenResponse is null)
            return BadRequest("Invalid Data");

        UserAuthResponse UserDto = new UserAuthResponse
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
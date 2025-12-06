using Microsoft.AspNetCore.Mvc;
using OnlineQuizSystem.API.Response;
using OnlineQuizSystem.API.Services;
using OnlineQuizSystem.Business.Interfaces;
using OnlineQuizSystem.Business.Requests;

namespace OnlineQuizSystem.API.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly ILoginManager _LoginManager;
    public AuthController(ILoginManager LoginManager)
    {
        _LoginManager = LoginManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginRequest request)
    {
        var user = await _LoginManager.CheckCredentialsAsync(request);

        if (user is null)
            return BadRequest("Invalid Data");

        var authModel = new Models.AuthModel
        {
            AccessToken = response.AceessToken,
            Username = response.Username,
            UserEmail = response.UserEmail,
            role = response.Role
        };
        return Ok(response);
    }


}
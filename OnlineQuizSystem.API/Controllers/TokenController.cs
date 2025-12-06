using Microsoft.AspNetCore.Mvc;
using OnlineQuizSystem.API.Interfaces;
using OnlineQuizSystem.API.Services;

namespace OnlineQuizSystem.API.Controllers;

[ApiController]
[Route("token")]
public class TokenController(ITokenProvider tokenProvider) : ControllerBase
{
    [HttpPost("generate")]
    public IActionResult GenerateToken(GenerateTokenRequest request)
    {
        return Ok();
    }
    
    [HttpPost("refresh")]
    public IActionResult RefreshToken( RefreshTokenRequest request)
    {
        return Ok();
    }
}
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineQuizSystem.Enums;
using OnlineQuizSystem.Interfaces;
using OnlineQuizSystem.Requests;

namespace OnlineQuizSystem.Controllers;

[ApiController]
[Authorize(Roles = nameof(Role.Student))]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]

public class AttemptController : ControllerBase
{
    private readonly IAttemptService _attemptService;
    public AttemptController(IAttemptService attemptService)
    {
        _attemptService = attemptService;
    }
    [HttpPost("quizzes/{quizId:guid}/attempts")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAttempt(Guid quizId, CreateQuizAttemptRequest request)
    {
        Guid studentId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var attemptResult = await _attemptService.CreateAttemptAsync(request, studentId, quizId);

        if (attemptResult is false)
        {
            return Problem(
                statusCode: StatusCodes.Status400BadRequest,
                title: "Failed to create quiz attempt",
                detail: "The quiz attempt could not be created due to business logic constraints.");
        }

        return Ok("Quiz attempt created successfully");
    }

}


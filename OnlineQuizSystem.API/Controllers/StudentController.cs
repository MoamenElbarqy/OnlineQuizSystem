using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineQuizSystem.API.Controllers;

[ApiController]
[Route("student")]
[Authorize(Roles = "Student")]
public class StudentController : ControllerBase
{
    [HttpPost("quizzes/{quizId:guid}/attempts")]
    public Task<IActionResult> StartQuiz(Guid quizId)
    {
        return Task.FromResult<IActionResult>(Ok());
    }
    [HttpPost("attempts/{attemptId:guid}/submit")]
    public Task<IActionResult> SubmitQuiz(Guid attemptId)
    {
        return Task.FromResult<IActionResult>(Ok());
    }
}
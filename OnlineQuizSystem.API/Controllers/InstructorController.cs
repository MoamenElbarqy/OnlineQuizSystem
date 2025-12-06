using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineQuizSystem.Business.Request;

namespace OnlineQuizSystem.API.Controllers;

[ApiController]
[Authorize(Roles = "Instructor")]
[Route("instructor")]
public class InstructorController : ControllerBase
{
    [HttpPost("quizzes")]
    public Task<IActionResult> CreateQuiz( [FromBody] CreateQuizRequest request)
    {
        return Task.FromResult<IActionResult>(Ok());
    }

    [HttpGet("quizzes")]
    public Task<IActionResult> GetAllQuizzes()
    {
        return Task.FromResult<IActionResult>(Ok());
    }

    [HttpGet("quizzes/{quizId:guid}")]
    public Task<IActionResult> GetQuizById(Guid quizId)
    {
        return Task.FromResult<IActionResult>(Ok());
    }

    [HttpDelete("quizzes/{quizId:guid}")]
    public Task<IActionResult> DeleteQuiz(Guid quizId)
    {
        return Task.FromResult<IActionResult>(Ok());
    }

    [HttpPut("quizzes/{quizId:guid}")]
    public Task<IActionResult> UpdateQuiz(Guid quizId)
    {
        return Task.FromResult<IActionResult>(Ok());
    }
}
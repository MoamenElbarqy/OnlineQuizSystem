using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineQuizSystem.Business.Request;
using OnlineQuizSystem.Business.Services;

namespace OnlineQuizSystem.API.Controllers;

[ApiController]
[Authorize(Roles = "Instructor")]
[Route("instructor")]
public class InstructorController(QuizService quizService) : ControllerBase
{

    [HttpPost("quizzes")]
    public Task<IActionResult> CreateQuiz( [FromBody] CreateQuizRequest request)
    {
        quizService.Create(request);
        
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
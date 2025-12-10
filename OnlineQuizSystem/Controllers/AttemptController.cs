using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineQuizSystem.Business.Interfaces;
using OnlineQuizSystem.Business.Requests;
using OnlineQuizSystem.Data.Enums;

namespace OnlineQuizSystem.API.Controllers;

// [Route("api/[controller]")]
[ApiController]
[Authorize(Roles = nameof(Role.Student))]
public class AttemptController : ControllerBase
{
    private readonly IQuizService _quizService;
    private readonly IAttemptService _attemptService;
    public AttemptController(IQuizService quizService, IAttemptService attemptService)
    {
        _attemptService = attemptService;
        _quizService = quizService;
    }
    [HttpPost("quizzes/{quizId:guid}/attempts")]
    public async Task<IActionResult> CreateAttempt(Guid quizId, CreateAttemptRequest request)
    {
        Guid studentId = Guid.Parse(User.Identity.Name);

        var quiz = await _quizService.GetById(quizId);

        if (quiz is null)
        {
            return NotFound("Quiz not found");
        }

        if (quiz.Status != QuizStatus.InProgress)
        {
            return BadRequest("Quiz has already been started or completed");
        }

        var result = await _attemptService.Create(request, studentId);

        if(!result)
        {
            return BadRequest("Failed to create quiz attempt");
        }

        return Ok("Quiz attempt created successfully");
    }
    public Task<IActionResult> SubmitQuiz(int quizId)
    {
    }
}

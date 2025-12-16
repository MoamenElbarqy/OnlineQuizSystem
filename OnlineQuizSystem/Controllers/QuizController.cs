using System.Security.Claims;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineQuizSystem.Enums;
using OnlineQuizSystem.Interfaces;
using OnlineQuizSystem.Requests;
using OnlineQuizSystem.Responses;
namespace OnlineQuizSystem.API.Controllers;

[ApiController]
[Route("api/quizzes")]

[Authorize(Roles = nameof(Role.Instructor))]
[ProducesResponseType<ProblemDetails>(StatusCodes.Status401Unauthorized)]
[ProducesResponseType<ProblemDetails>(StatusCodes.Status403Forbidden)]
[ProducesResponseType<ProblemDetails>(StatusCodes.Status500InternalServerError)]
public class QuizController : ControllerBase
{
    private readonly IQuizService _quizService;
    private readonly LinkGenerator _linkGenerator;
    

    public QuizController(IQuizService quizService, LinkGenerator linkGenerator)
    {
        _quizService = quizService;
        _linkGenerator = linkGenerator;
    }

    [HttpPost]
    [ProducesResponseType<QuizResponse>(StatusCodes.Status201Created)]
    [ProducesResponseType<ValidationProblemDetails>(StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> CreateQuiz(CreateQuizRequest request)
    {
        var instructorId = GetInstructorId();

        var createdQuiz = await _quizService.CreateQuizAsync(request, instructorId);

        if (createdQuiz is null)
        {
            return BadRequest(new ProblemDetails
            {
                Title = "Failed to create quiz",
                Detail = "The quiz could not be created due to business logic constraints.",
                Instance = HttpContext.Request.Path
            });
        }

        return CreatedAtAction(
        nameof(GetQuizById),
        new { id = createdQuiz.Id },
        QuizResponse.From(createdQuiz));

    }
    [HttpGet("{quizId:guid}")]
    [ProducesResponseType<QuizResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound)]


    public async Task<IActionResult> GetQuizById(Guid quizId)
    {
        var instructorId = GetInstructorId();

        var quiz = await _quizService.GetByIdAsync(quizId, instructorId);

        if(quiz == null)
        {
            return NotFound(new ProblemDetails
            {
                Title = "Quiz not found",
                Detail = $"Quiz with ID {quizId} was not found or you don't have permission to access it.",
                Instance = HttpContext.Request.Path
            });
        }
        return Ok(QuizResponse.From(quiz));
    }
    [HttpGet]


    [ProducesResponseType<List<QuizResponse>>(StatusCodes.Status200OK)]

    public async Task<IActionResult> GetAllQuizzes()
    {
        var instructorId = GetInstructorId();

        var quizzes = await _quizService.GetAllQuizzesAsync(instructorId);

        return Ok(quizzes.Select(QuizResponse.From));
    }
    [HttpPut("{quizId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound)]
    [ProducesResponseType<ValidationProblemDetails>(StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> UpdateQuiz(Guid quizId, UpdateQuizRequest request)
    {
        var instructorId = GetInstructorId();

        var updatedQuiz = await _quizService.UpdateQuizAsync(quizId, request, instructorId);

        if (updatedQuiz is null)
        {
            return NotFound(new ProblemDetails
            {
                Title = "Quiz not found",
                Detail = $"Quiz with ID {quizId} was not found or you don't have permission to update it.",
                Instance = HttpContext.Request.Path
            });
        }

    var locationUrl = _linkGenerator.GetUriByAction(
    HttpContext,
    action: nameof(GetQuizById),
    controller: null,  // current controller
    values: new { quizId = updatedQuiz.Id });
    
        Response.Headers.Append("Location", locationUrl);
    
        return NoContent();

    }
    [HttpDelete("{quizId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound)]
    

    public async Task<IActionResult> DeleteQuiz(Guid quizId)
    {
        var instructorId = GetInstructorId();

        var result = await _quizService.DeleteAsync(quizId, instructorId);

        if (!result)
        {
            return NotFound(new ProblemDetails
            {
                Title = "Quiz not found",
                Detail = $"Quiz with ID {quizId} was not found or you don't have permission to delete it.",
                Instance = HttpContext.Request.Path
            });
        }

        return NoContent();
    }
    private Guid GetInstructorId()
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return Guid.Parse(userIdClaim!);
    }

}

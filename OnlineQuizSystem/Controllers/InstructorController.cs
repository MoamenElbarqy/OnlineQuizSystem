using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineQuizSystem.Enums;
using OnlineQuizSystem.Interfaces;
using OnlineQuizSystem.Requests;
using OnlineQuizSystem.Responses;

namespace OnlineQuizSystem.Controllers;

[ApiController]
[Route("api/instructors")]
[Authorize(Roles = nameof(Role.Instructor))]
public class InstructorController : ControllerBase
{
    private readonly IInstructorService _instructorService;
    public InstructorController(IInstructorService instructorService)
    {
        _instructorService = instructorService;
    }
    [HttpPost()]
    [ProducesResponseType<InstructorResponse>(StatusCodes.Status201Created)]
    [ProducesResponseType<ValidationProblemDetails>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateInstructor(CreateInstructorRequest request)
    {
        var createdInstructor = await _instructorService.CreateInstructorAsync(request);

        if(createdInstructor is null)
        {
            return BadRequest(new ProblemDetails
            {
                Title = "Failed to create instructor",
                Detail = "The instructor could not be created due to business logic constraints.",
                Instance = HttpContext.Request.Path
            });
        }
        return CreatedAtAction(
            nameof(GetInstructorById),
            new { instructorId = createdInstructor.Id },
            InstructorResponse.From(createdInstructor));
    }
    [HttpGet("{instructorId:guid}")]
    [ProducesResponseType<InstructorResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetInstructorById(Guid instructorId)
    {
        var instructor = await _instructorService.GetInstructorByIdAsync(instructorId);

        if (instructor is null)
        {
            return NotFound(new ProblemDetails
            {
                Title = "Instructor not found",
                Detail = $"No instructor found with ID {instructorId}.",
                Instance = HttpContext.Request.Path
            });
        }

        return Ok(InstructorResponse.From(instructor));
    }
    [HttpGet("hello")]
    public IActionResult SayHello()
    {
        return Ok("Hello from InstructorController!");
    }
}

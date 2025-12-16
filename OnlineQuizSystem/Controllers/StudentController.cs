namespace OnlineQuizSystem.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineQuizSystem.Enums;
using OnlineQuizSystem.Interfaces;
using OnlineQuizSystem.Requests;
using OnlineQuizSystem.Responses;

[ApiController]
[Route("api/students")]
[Authorize(Roles = nameof(Role.Student))]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;
    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }
    [HttpPost()]
    [ProducesResponseType<StudentResponse>(StatusCodes.Status201Created)]
    [ProducesResponseType<ValidationProblemDetails>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateStudent(CreateStudentRequest request)
    {
        var createdStudent = await _studentService.CreateStudentAsync(request);

        if(createdStudent is null)
        {
            return BadRequest(new ProblemDetails
            {
                Title = "Failed to create student",
                Detail = "The student could not be created due to business logic constraints.",
                Instance = HttpContext.Request.Path
            });
        }
        return CreatedAtAction(
            nameof(GetStudentById),
            new { studentId = createdStudent.Id },
            StudentResponse.From(createdStudent));
        
    }
    [HttpGet("{studentId:guid}")]
    [ProducesResponseType<StudentResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetStudentById(Guid studentId)
    {
        var student = await _studentService.GetStudentByIdAsync(studentId);

        if (student is null)
        {
            return NotFound(new ProblemDetails
            {
                Title = "Student not found",
                Detail = $"No student found with ID {studentId}.",
                Instance = HttpContext.Request.Path
            });
        }

        return Ok(StudentResponse.From(student));
        
    }
    [HttpGet("hello")]
    public IActionResult HelloStudent()
    {
        return Ok("Hello, Student!");
    }

}
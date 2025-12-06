using Microsoft.AspNetCore.Mvc;

namespace OnlineQuizSystem.API.Controllers;

[ApiController]
[Route("admin")]
public class AdminController: ControllerBase
{
    [HttpGet("students")]
    public Task<IActionResult> GetStudents()
    {
        return Task.FromResult<IActionResult>(Ok());
    }
    [HttpGet("students")]
    public Task<IActionResult> GetStudentsById()
    {
        return Task.FromResult<IActionResult>(Ok());
    }
    [HttpPost("students")]
    public Task<IActionResult> CreateStudent()
    {
        return Task.FromResult<IActionResult>(Ok());
    }
    [HttpDelete("students/{studentId:guid}")]
    public Task<IActionResult> DeleteStudent()
    {
        return Task.FromResult<IActionResult>(Ok());
    }
    
    [HttpPut("students/{studentId:guid}")]
    public Task<IActionResult> UpdateStudent()
    {
        return Task.FromResult<IActionResult>(Ok());
    }
    [HttpGet("instructors")]
    public Task<IActionResult> GetInstructors()
    {
        return Task.FromResult<IActionResult>(Ok());
    }

    [HttpGet("instructors/{instructorId:guid}")]
    public Task<IActionResult> GetInstructorById()
    {
        return Task.FromResult<IActionResult>(Ok());
    }
    [HttpPut("instructors/{instructorId:guid}")]
    public Task<IActionResult> UpdateInstructor()
    {
        return Task.FromResult<IActionResult>(Ok());
    }
    [HttpDelete("instructors/{instructorId:guid}")]
    public Task<IActionResult> DeleteInstructor()
    {
        return Task.FromResult<IActionResult>(Ok());
    }
    [HttpPost("instructors")]
    public Task<IActionResult> CreateInstructor()
    {
        return Task.FromResult<IActionResult>(Ok());
    }
    
}
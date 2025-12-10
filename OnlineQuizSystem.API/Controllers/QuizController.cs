using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineQuizSystem.Business.Interfaces;
using OnlineQuizSystem.Business.Request;
using OnlineQuizSystem.Data.Enums;

namespace OnlineQuizSystem.API.Controllers;

[ApiController]
[Route("quizzes")]
[Authorize(Roles = nameof(Role.Instructor))]
public class QuizController : ControllerBase
{   
    [HttpPost]
    public Task<IActionResult> CreateQuiz(CreateQuizRequest request)
    {
    }
    [HttpGet]
    public Task<IActionResult> GetQuizById(int id)
    {
        return Ok();
    }
    [HttpGet]
    public Task<IActionResult> GetAllQuizzes()
    {
        return Ok();
    }
    [HttpPut]
    public Task<IActionResult> UpdateQuiz(int id, UpdateQuizRequest request)
    {
        return Ok();

    }
    [HttpDelete]
    public Task<IActionResult> DeleteQuiz(int id)
    {
        return ;
    }
    
}


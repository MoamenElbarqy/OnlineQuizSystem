using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineQuizSystem.Business.Interfaces;
using OnlineQuizSystem.Business.Request;

namespace OnlineQuizSystem.API.Controllers;

[ApiController]
[Route("quiz")]
[Authorize]
public class QuizController : ControllerBase
{
    /*private readonly IQuizService _quizService;
    
    public QuizController(IQuizService quizService)
    {
        _quizService = quizService;
    }
    [HttpPost]
    [Authorize(Roles = "Instructor")]
    public IActionResult CreateQuiz(CreateQuizRequest quiz)
    {
        return Ok();
    }
    [Authorize(Roles = "Instructor")]
    public IActionResult GetAll()
    {
        
    }*/
}


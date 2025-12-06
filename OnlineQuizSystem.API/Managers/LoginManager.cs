using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OnlineQuizSystem.API.Interfaces;
using OnlineQuizSystem.API.LoginHandlers;
using OnlineQuizSystem.API.Response;
using OnlineQuizSystem.Business.Interfaces;
using OnlineQuizSystem.Business.Requests;
using OnlineQuizSystem.Business.Services;
using OnlineQuizSystem.Data.Models;

namespace OnlineQuizSystem.Business.Managers;

class LoginManager : ILoginManager
{
    private readonly List<ILoginHandler> _handlers;


    public LoginManager(
                        StudentService studentService,
                        InstructorService instructorService,
                        AdminService AdminService)
    {
        _handlers = new List<ILoginHandler>
        {
            new StudentLoginHandler(studentService),
            new InstructorLoginHandler(instructorService),
            new AdminLoginHandler(AdminService)
        };
    }
    public async Task<User?> ProcessLoginAsync(UserLoginRequest request)
    {
        var handler = _handlers.FirstOrDefault(h => h.CanHanlde(request.Role));

        if (handler is null)
            return null;

        return await handler.HandleLoginAsync(request);
    }
}
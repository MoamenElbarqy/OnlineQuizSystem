using OnlineQuizSystem.API.Interfaces;
using OnlineQuizSystem.API.Response;
using OnlineQuizSystem.API.Services;
using OnlineQuizSystem.Business.Requests;
using OnlineQuizSystem.Business.Services;
using OnlineQuizSystem.Data.Enums;

namespace OnlineQuizSystem.API.LoginHandlers;

public class StudentLoginHandler(StudentService studentService) : ILoginHandler
{
    public bool CanHanlde(Role role)
    {
        return role == Role.Student;
    }

    public async Task<UserTokenResponse?> HandleLoginAsync(UserLoginRequest request)
    {
        var student = studentService.IsExsisted(request);

        if (student is null)
            return null;

        var gnerateTokenRequest = new GenerateTokenRequest
        {
            Id = student.Id,
            Role = student.Role
        };

        var tokenResponse = tokenProvider.GenerateToken(gnerateTokenRequest);

        return tokenResponse;

    }
}
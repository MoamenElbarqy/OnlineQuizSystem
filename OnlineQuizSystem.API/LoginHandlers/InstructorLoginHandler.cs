using OnlineQuizSystem.API.Interfaces;
using OnlineQuizSystem.API.Response;
using OnlineQuizSystem.API.Services;
using OnlineQuizSystem.Business.Requests;
using OnlineQuizSystem.Business.Services;
using OnlineQuizSystem.Data.Enums;

namespace OnlineQuizSystem.API.LoginHandlers;

public class InstructorLoginHandler(InstructorService instructorService,
                                    ITokenProvider tokenProvider) : ILoginHandler
{
    public bool CanHanlde(Role role)
    {
        return role == Role.Instructor;
    }
    public Task<TokenResponse?> HandleLoginAsync(UserLoginRequest request)
    {
        var instructor = instructorService.IsExsisted(request);

        if(instructor is null)
            return null;

        var gnerateTokenRequest = new GenerateTokenRequest
        {
            Id = instructor.Id,
            Role = instructor.Role
        };
        
        var tokenResponse = tokenProvider.GenerateToken(gnerateTokenRequest);

        return tokenResponse;
    }
}
using OnlineQuizSystem.Data;
using OnlineQuizSystem.Interfaces;
using OnlineQuizSystem.Models;
using OnlineQuizSystem.Requests;

namespace OnlineQuizSystem.Business.Services;

public class InstructorService(AppDbContext dbContext) : IInstructorService
{
    public Instructor? IsExisted(UserLoginRequest request)
    {
        var instructor = repository.Find(request.Email, request.Password);


        return instructor;
    }

    public Instructor? IsExisted(UserLoginRequest request)
    {
        throw new NotImplementedException();
    }
}

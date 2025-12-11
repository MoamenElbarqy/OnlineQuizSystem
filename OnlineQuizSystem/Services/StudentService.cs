using OnlineQuizSystem.Business.Interfaces;
using OnlineQuizSystem.Business.Requests;
using OnlineQuizSystem.Models;

namespace OnlineQuizSystem.Business.Services;



public class StudentService(AppDbContext dbContext) : IStudentService
{
    public Student? IsExisted(UserLoginRequest request)
    {
        var student = repository.Find(request.Email, request.Password);

        if (student is null)
            return null;

        return student;
    }
}

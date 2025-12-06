using System;
using OnlineQuizSystem.Business.Requests;
using OnlineQuizSystem.Data.Models;
using OnlineQuizSystem.Data.Repositories;

namespace OnlineQuizSystem.Business.Services;

public class InstructorService(InstructorRepository repository)
{
    public Instructor? IsExsisted(UserLoginRequest request)
    {
        var instructor = repository.Find(request.Email, request.Password);

        if (instructor is null)
            return null;

        

        return instructor;
    }
}

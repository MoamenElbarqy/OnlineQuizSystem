using System;
using OnlineQuizSystem.Business.Requests;
using OnlineQuizSystem.Data.Models;
using OnlineQuizSystem.Data.Repositories;

namespace OnlineQuizSystem.Business.Services;

public class StudentService(StudentRepository repository)
{
    public Student? IsExsisted(UserLoginRequest request)
    {
        var student = repository.Find(request.Email,request.Password);

        if(student is null)
            return null;

        return student;
    }   
}

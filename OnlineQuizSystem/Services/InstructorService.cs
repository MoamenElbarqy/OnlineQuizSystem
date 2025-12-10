using System;
using OnlineQuizSystem.Business.Interfaces;
using OnlineQuizSystem.Business.Requests;
using OnlineQuizSystem.Data.Models;
using OnlineQuizSystem.Data.Repositories;

namespace OnlineQuizSystem.Business.Services;

public class InstructorService(InstructorRepository repository) : IInstructorService
{
    public Instructor? IsExisted(UserLoginRequest request)
    {
        var instructor = repository.Find(request.Email, request.Password);


        return instructor;
    }
}

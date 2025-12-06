using System;
using OnlineQuizSystem.Business.Requests;
using OnlineQuizSystem.Data.Models;
using OnlineQuizSystem.Data.Repositories;

namespace OnlineQuizSystem.Business.Services;

public class AdminService(AdminRepository repository)
{
    public Admin? IsExsisted(UserLoginRequest request)
    {
        var admin = repository.Find(request.Email, request.Password);

        if (admin is null)
            return null;

        
        return admin;
    }
}

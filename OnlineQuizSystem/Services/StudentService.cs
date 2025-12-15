using OnlineQuizSystem.Data;
using OnlineQuizSystem.Interfaces;
using OnlineQuizSystem.Models;
using OnlineQuizSystem.Requests;
using Microsoft.EntityFrameworkCore;
using OnlineQuizSystem.Enums;

namespace OnlineQuizSystem.Business.Services;

public class StudentService(AppDbContext dbContext) : IStudentService
{
    public async Task<Student?> CreateStudentAsync(CreateStudentRequest request)
    {
        var existingStudent = await dbContext.Students
            .FirstOrDefaultAsync(s => s.Email == request.UserInfo.Email);
        if (existingStudent is null)
        {
            return null;
        }
        var student = new Student
        {
            Id = Guid.NewGuid(),
            Name = request.UserInfo.Name,
            Email = request.UserInfo.Email,
            Password = request.UserInfo.Password,
            Role = Role.Student,
            Department = request.Department,
            Level = request.Level
        };

        dbContext.Students.Add(student);
        await dbContext.SaveChangesAsync();

        return student;
    }
}

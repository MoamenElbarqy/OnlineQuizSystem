using Microsoft.EntityFrameworkCore;
using OnlineQuizSystem.Data;
using OnlineQuizSystem.Enums;
using OnlineQuizSystem.Interfaces;
using OnlineQuizSystem.Models;
using OnlineQuizSystem.Requests;

namespace OnlineQuizSystem.Business.Services;

public class InstructorService(AppDbContext dbContext) : IInstructorService
{
    public async Task<Instructor?> CreateInstructorAsync(CreateInstructorRequest request)
    {
        var existingStudent = await dbContext.Instructors
            .FirstOrDefaultAsync(s => s.Email == request.UserInfo.Email);

        if (existingStudent is null)
        {
            return null;
        }
        var instructor = new Instructor
        {
            Id = Guid.NewGuid(),
            Name = request.UserInfo.Name,
            Email = request.UserInfo.Email,
            Password = request.UserInfo.Password,
            Role = Role.Instructor,
            Salary = request.Salary
        };

        dbContext.Instructors.Add(instructor);
        await dbContext.SaveChangesAsync();

        return instructor;
    
    }
}

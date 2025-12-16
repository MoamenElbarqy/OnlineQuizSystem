using Microsoft.EntityFrameworkCore;
using OnlineQuizSystem.Data;
using OnlineQuizSystem.Enums;
using OnlineQuizSystem.Helpers;
using OnlineQuizSystem.Interfaces;
using OnlineQuizSystem.Models;
using OnlineQuizSystem.Requests;

namespace OnlineQuizSystem.Business.Services;

public class InstructorService(AppDbContext dbContext) : IInstructorService
{
    public async Task<Instructor?> CreateInstructorAsync(CreateInstructorRequest request)
    {
        var existingInstructor = await dbContext.Instructors
            .FirstOrDefaultAsync(i => i.Email == request.UserInfo.Email);

        if (existingInstructor is not null)
        {
            throw new InvalidOperationException("An instructor with the same email already exists.");
        }
        var instructor = new Instructor
        {
            Id = Guid.NewGuid(),
            Name = request.UserInfo.Name,
            Email = request.UserInfo.Email,
            Password = PasswordHelper.Hash(request.UserInfo.Password),
            Role = Role.Instructor,
            Salary = request.Salary
        };

        dbContext.Instructors.Add(instructor);

        await dbContext.SaveChangesAsync();

        return instructor;
    
    }

    public Task<Instructor?> GetInstructorByIdAsync(Guid instructorId)
    {
        return dbContext.Instructors
            .FirstOrDefaultAsync(i => i.Id == instructorId);
    }
}

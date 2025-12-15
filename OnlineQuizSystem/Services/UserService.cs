using Microsoft.EntityFrameworkCore;
using OnlineQuizSystem.Data;
using OnlineQuizSystem.Interfaces;
using OnlineQuizSystem.Models;

namespace OnlineQuizSystem.Services;

public class UserService(AppDbContext dbContext) : IUserService
{
    public async Task<Instructor?> GetByIdAsync(Guid instructorId)
    {
        return await dbContext.Instructors.FirstOrDefaultAsync(i => i.Id == instructorId);
    }
    public async Task<User?> FindAsync(string email, string password)
    {
        return await dbContext.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
    }
}
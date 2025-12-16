using Microsoft.EntityFrameworkCore;
using OnlineQuizSystem.Data;
using OnlineQuizSystem.Helpers;
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
         var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null)
            return null;

        bool valid = PasswordHelper.Verify(password, user.Password);

        if (!valid)
            return null;

        return user;
    }
}
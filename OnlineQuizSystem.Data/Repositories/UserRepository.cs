using Microsoft.EntityFrameworkCore;
using OnlineQuizSystem.Data.Models;

namespace OnlineQuizSystem.Data.Repositories;

public class UserRepository(AppDbContext context) 
{
    public async Task<User?> Find(string email, string password)
    {
        var user = context.Users
            .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

        return await user;
    }
}
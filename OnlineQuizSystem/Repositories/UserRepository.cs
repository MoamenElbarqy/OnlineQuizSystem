using Microsoft.EntityFrameworkCore;
using OnlineQuizSystem.Data.Interfaces;
using OnlineQuizSystem.Data.Models;

namespace OnlineQuizSystem.Data.Repositories;

public class UserRepository(AppDbContext context) :IUserRepository
{
    public async Task<User?> Find(string email, string password)
    {
        var user = context.Users
            .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

        return await user;
    }

    public Task<User?> FindAsync(string email, string password)
    {
        throw new NotImplementedException();
    }
}
using OnlineQuizSystem.Data.Models;

namespace OnlineQuizSystem.Data.Repositories;

public class UserRepository(AppDbContext context) 
{
    public User? Find(string email, string password)
    {
        var user = context.Users
            .FirstOrDefault(u => u.Email == email && u.Password == password);

        return user;
    }
}
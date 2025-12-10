using OnlineQuizSystem.Data.Models;

namespace OnlineQuizSystem.Data.Interfaces;
public interface IUserRepository
{
    Task<User?> FindAsync(string email, string password);
}
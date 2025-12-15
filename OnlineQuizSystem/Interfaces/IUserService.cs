using OnlineQuizSystem.Models;

namespace OnlineQuizSystem.Interfaces;

public interface IUserService
{
    public Task<Instructor?> GetByIdAsync(Guid instructorId);
    public Task<User?> FindAsync(string email, string password);
}

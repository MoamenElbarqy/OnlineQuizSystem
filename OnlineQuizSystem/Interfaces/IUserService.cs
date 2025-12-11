using OnlineQuizSystem.Models;

namespace OnlineQuizSystem.Interfaces;

public interface IUserService
{
    Task<User?> IsExistedAsync(string email, string password);
}

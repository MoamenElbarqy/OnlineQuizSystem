using OnlineQuizSystem.Data.Models;

namespace OnlineQuizSystem.Business.Interfaces;

public interface IUserService
{
    Task<User?> IsExistedAsync(string email, string password);
}

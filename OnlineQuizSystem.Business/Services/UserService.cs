using OnlineQuizSystem.Business.Interfaces;
using OnlineQuizSystem.Data.Models;
using OnlineQuizSystem.Data.Repositories;

namespace OnlineQuizSystem.Business.Services;

public class UserService(UserRepository userRepository) : IUserService
{
    public async Task<User?> IsExistedAsync(string email, string password)
    {
        var user = await userRepository.Find(email, password);

        return user;
    }
}
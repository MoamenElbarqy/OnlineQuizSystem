using OnlineQuizSystem.Data.Models;
using OnlineQuizSystem.Data.Repositories;

namespace OnlineQuizSystem.Business.Services;

public class UserService(UserRepository userRepository)
{
    public User? IsExisted(string email, string password)
    {
        var user = userRepository.Find(email, password);

        return user;
    }
}
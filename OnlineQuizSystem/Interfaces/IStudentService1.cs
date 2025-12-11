using OnlineQuizSystem.Requests;
using OnlineQuizSystem.Models;

namespace OnlineQuizSystem.Interfaces;

public interface IStudentService
{
    Student? IsExisted(UserLoginRequest request);
}

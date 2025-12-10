using OnlineQuizSystem.Business.Requests;
using OnlineQuizSystem.Data.Models;

namespace OnlineQuizSystem.Business.Interfaces;

public interface IStudentService
{
    Student? IsExisted(UserLoginRequest request);
}

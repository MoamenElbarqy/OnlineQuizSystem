using OnlineQuizSystem.Business.Requests;
using OnlineQuizSystem.Models;

namespace OnlineQuizSystem.Interfaces;

public interface IInstructorService
{
    Instructor? IsExisted(UserLoginRequest request);
}

using OnlineQuizSystem.Business.Requests;
using OnlineQuizSystem.Data.Models;

namespace OnlineQuizSystem.Business.Interfaces;

public interface IInstructorService
{
    Instructor? IsExisted(UserLoginRequest request);
}

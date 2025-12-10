using OnlineQuizSystem.Data.Models;

namespace OnlineQuizSystem.Data.Interfaces;

public interface IInstructorRepository
{
    Instructor? Find(string email, string password);
}

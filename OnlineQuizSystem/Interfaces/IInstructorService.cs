using OnlineQuizSystem.Models;
using OnlineQuizSystem.Requests;

namespace OnlineQuizSystem.Interfaces;

public interface IInstructorService
{
    Task<Instructor?> CreateInstructorAsync(CreateInstructorRequest request);
}

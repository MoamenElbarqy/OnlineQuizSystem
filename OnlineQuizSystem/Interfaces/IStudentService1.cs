using OnlineQuizSystem.Models;
using OnlineQuizSystem.Requests;

namespace OnlineQuizSystem.Interfaces;

public interface IStudentService
{
    public Task<Student?> CreateStudentAsync(CreateStudentRequest request);

    public Task<Student?> GetStudentByIdAsync(Guid studentId);
}


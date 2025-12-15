using OnlineQuizSystem.Requests;

namespace OnlineQuizSystem.Interfaces;

public interface IAttemptService
{
    Task<bool> CreateAttemptAsync(CreateQuizAttemptRequest request, Guid studentId, Guid QuizId);
}

using OnlineQuizSystem.Business.Requests;

namespace OnlineQuizSystem.Business.Interfaces;

public interface IAttemptService
{
    Task<bool> Create(CreateAttemptRequest request, Guid studentId, Guid QuizId);
}

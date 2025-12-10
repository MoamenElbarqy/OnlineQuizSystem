using OnlineQuizSystem.Business.Interfaces;
using OnlineQuizSystem.Business.Requests;
using OnlineQuizSystem.Data.Interfaces;

namespace OnlineQuizSystem.Business.Services;

public class AttemptService(IAttemptRepository attemptRepository) : IAttemptService
{
    public async Task<bool> Create(CreateAttemptRequest request, Guid studentId, Guid QuizId)
    {
        return await attemptRepository.CreateAttempt(QuizId, studentId, DateTime.UtcNow);
    }

}

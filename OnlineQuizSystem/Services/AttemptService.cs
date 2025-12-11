using OnlineQuizSystem.Business.Requests;
using OnlineQuizSystem.Requests;
using OnlineQuizSystem.Data;
using OnlineQuizSystem.Interfaces;

namespace OnlineQuizSystem.Business.Services;

public class AttemptService(AppDbContext dbContext) : IAttemptService
{
    public async Task<bool> Create(CreateAttemptRequest request, Guid studentId, Guid QuizId)
    {
        return await attemptRepository.CreateAttempt(QuizId, studentId, DateTime.UtcNow);
    }

}

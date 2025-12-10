using System;
using OnlineQuizSystem.Data.Interfaces;
using OnlineQuizSystem.Data.Models;

namespace OnlineQuizSystem.Data.Repositories;

public class AttemptController(AppDbContext dbContext) : IAttemptRepository
{
    public async Task<bool> CreateAttempt(Guid quizId, Guid studentId, DateTime StatedAt)
    {
        var attempt = new StudentQuiz
        {
            QuizId = quizId,
            StudentId = studentId,
            StartedAt = StatedAt
        };
        await dbContext.StudentQuizzes.AddAsync(attempt);
        return await dbContext.SaveChangesAsync() > 0;
    }
}

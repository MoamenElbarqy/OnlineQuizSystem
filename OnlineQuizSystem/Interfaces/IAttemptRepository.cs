using System;

namespace OnlineQuizSystem.Data.Interfaces;

public interface IAttemptRepository
{
    Task<bool> CreateAttempt(Guid quizId, Guid studentId, DateTime StatedAt);
}

using Microsoft.EntityFrameworkCore;
using OnlineQuizSystem.Data.Interfaces;
using OnlineQuizSystem.Data.Models;

namespace OnlineQuizSystem.Data.Repositories;

public class QuizRepository(AppDbContext context) : IQuizRepository
{
    public async Task<bool> AddAsync(Quiz quiz)
    {
        await context.Quizzes.AddAsync(quiz);

        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var quiz = await context.Quizzes.FirstOrDefaultAsync(q => q.Id == id);

        if (quiz is null)
            return false;

        context.Quizzes.Remove(quiz);
        return await context.SaveChangesAsync() > 0;

    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        var quiz = await context.Quizzes.FirstOrDefaultAsync(q => q.Id == id);

        if (quiz is null)
            return false;
        return true;
    }

    public async Task<Quiz> GetByIdAsync(Guid id)
    {
        var quiz = await context.Quizzes.FirstOrDefaultAsync(q => q.Id == id);

        if (quiz is null)
            throw new Exception("Quiz not found");
        return quiz;
    }

    public async Task<IEnumerable<Quiz>> GetByInstructorIdAsync(Guid instructorId)
    {
       var quizzes = context.Quizzes.Where(q => q.InstructorId == instructorId);

        return quizzes;
    }

    public async Task<bool> UpdateAsync(Quiz quiz)
    {
        var existingQuiz = context.Quizzes.FirstOrDefault(q => q.Id == quiz.Id);

        if(existingQuiz is null)
            throw new Exception("Quiz not found");

        context.Quizzes.Update(quiz);
        return await context.SaveChangesAsync() > 0;
    }
}

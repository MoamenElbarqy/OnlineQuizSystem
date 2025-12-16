using Microsoft.EntityFrameworkCore;
using OnlineQuizSystem.Data;
using OnlineQuizSystem.Interfaces;
using OnlineQuizSystem.Models;
using OnlineQuizSystem.Requests;

namespace OnlineQuizSystem.Business.Services;

public class QuizService(IUserService userService, AppDbContext dbContext) : IQuizService
{
    private async Task<Instructor?> GetInstructorAsync(Guid instructorId)
    {
        var instructor = await userService.GetByIdAsync(instructorId);

        if (instructor is null)
            throw new Exception("Instructor not found");

        return instructor;
    }
    public async Task<Quiz?> CreateQuizAsync(CreateQuizRequest request, Guid instructorId)
    {
        var instructor = await GetInstructorAsync(instructorId);


        var quiz = new Quiz
        {
            Id = Guid.NewGuid(),
            InstructorId = instructorId,
            Title = request.Title,
            CreatedAt = DateTime.UtcNow
        };

        foreach (var questionRequest in request.Questions)
        {
            var question = new Question
            {
                Id = Guid.NewGuid(),
                QuizId = quiz.Id,
                Title = questionRequest.Title,
                Points = questionRequest.Points,

            };

            for (int i = 0; i < questionRequest.Choices.Count; i++)
            {
                var choice = new Choice
                {
                    Id = Guid.NewGuid(),
                    Text = questionRequest.Choices[i],
                    QuestionId = question.Id
                };

                question.Choices.Add(choice);

                if (i == questionRequest.CorrectChoiceIndex)
                {
                    question.CorrectChoice = choice;
                    question.CorrectChoiceId = choice.Id;
                }
            }
        }
        dbContext.Quizzes.Add(quiz);
        await dbContext.SaveChangesAsync();

        return quiz;

    }

    public async Task<bool> DeleteAsync(Guid id, Guid instructorId)
    {
        var instructor = await GetInstructorAsync(instructorId);


        var quiz = await dbContext.Quizzes.FirstOrDefaultAsync(q => q.Id == id && q.InstructorId == instructorId);

        if (quiz is null)
            return false;
        dbContext.Quizzes.Remove(quiz);
        await dbContext.SaveChangesAsync();
        return true;

    }

    public async Task<Quiz?> UpdateQuizAsync(Guid id, UpdateQuizRequest request, Guid instructorId)
    {
        var instructor = await GetInstructorAsync(instructorId);


        var quizToUpdate = await GetByIdAsync(id, instructorId);

        if (quizToUpdate is null)
            return null;

        quizToUpdate.Title = request.Title;
        quizToUpdate.StartAt = request.StartTime;
        quizToUpdate.EndAt = request.EndTime;
        quizToUpdate.Questions.Clear();
        foreach (var questionRequest in request.Questions)
        {
            var question = new Question
            {
                Id = Guid.NewGuid(),
                QuizId = quizToUpdate.Id,
                Title = questionRequest.Title,
                Points = questionRequest.Points,

            };

            for (int i = 0; i < questionRequest.Choices.Count; i++)
            {
                var choice = new Choice
                {
                    Id = Guid.NewGuid(),
                    Text = questionRequest.Choices[i],
                    QuestionId = question.Id
                };

                question.Choices.Add(choice);

                if (i == questionRequest.CorrectChoiceIndex)
                {
                    question.CorrectChoice = choice;
                    question.CorrectChoiceId = choice.Id;
                }
            }
            quizToUpdate.Questions.Add(question);
        }
        quizToUpdate.UpdatedAt = DateTime.UtcNow;
        dbContext.Quizzes.Update(quizToUpdate);
        var result = await dbContext.SaveChangesAsync();

        if (result == 0)
            return null;
        return quizToUpdate;

    }

    public async Task<Quiz?> GetByIdAsync(Guid id, Guid instructorId)
    {
        return await dbContext.Quizzes.FirstOrDefaultAsync(q => q.Id == id && q.InstructorId == instructorId);
    }

    public async Task<IEnumerable<Quiz>> GetAllQuizzesAsync(Guid instructorId)
    {
        var instructor = await GetInstructorAsync(instructorId);

        var quizzes = await dbContext.Quizzes
            .Where(q => q.InstructorId == instructorId)
            .ToListAsync();

        return quizzes;

    }

    public async Task<Quiz?> GetByIdAsync(Guid id)
    {
        return await dbContext.Quizzes.FirstOrDefaultAsync(q => q.Id == id);
    }
}
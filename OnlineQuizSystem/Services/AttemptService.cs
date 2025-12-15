using OnlineQuizSystem.Requests;
using OnlineQuizSystem.Data;
using OnlineQuizSystem.Interfaces;
using OnlineQuizSystem.Models;

namespace OnlineQuizSystem.Business.Services;

public class AttemptService(AppDbContext dbContext,
                            IQuizService quizService) : IAttemptService
{
    public async Task<bool> CreateAttemptAsync(CreateQuizAttemptRequest request, Guid studentId, Guid QuizId)
    {
        var quiz = await quizService.GetByIdAsync(QuizId, Guid.Empty);

        if (quiz is null)
            throw new KeyNotFoundException("Quiz not found");

        var StudentQuizAttempt = new StudentQuiz
        {
            Id = Guid.NewGuid(),
            QuizId = QuizId,
            StudentId = studentId,
        };
        var StudentQuestionAttempts = new List<StudentQuestion>();

        foreach (var questionAttempt in request.QuestionAttempts)
        {
            var question = quiz.Questions.FirstOrDefault(q => q.Id == questionAttempt.QuestionId);
            if (question is null)
                throw new Exception("Question not found in the quiz");

            var selectedChoice = question.Choices.FirstOrDefault(c => c.Id == questionAttempt.SelectedChoiceId
             && c.QuestionId == question.Id);

            if (selectedChoice is null)
                throw new Exception("Selected choice index is out of range Or does not belong to the question");

            var studentQuestion = new StudentQuestion
            {
                Id = Guid.NewGuid(),
                QuestionId = question.Id,
                StudentQuizId = StudentQuizAttempt.Id,
                StudentChoiceId = selectedChoice.Id,
                StudentId = studentId
            };

        }
        dbContext.StudentQuizzes.Add(StudentQuizAttempt);
        var result = await dbContext.SaveChangesAsync() > 0;
        if (!result)
            return false;

        return true;
    }
}

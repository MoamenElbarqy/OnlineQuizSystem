using OnlineQuizSystem.Enums;
using OnlineQuizSystem.Models;

namespace OnlineQuizSystem.Responses;

public class QuizResponse
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public int NumberOfQuestions { get; private set; }
    public int TotalPoints { get; private set; }
    public DateTime StartAt { get; private set; }
    public DateTime EndAt { get; private set; }
    public string Status { get; private set; }

    public List<QuestionResponse> Questions { get; private set; } = new();
    public static QuizResponse From(Quiz quiz)
    {
        return new QuizResponse
        {
            Id = quiz.Id,
            Title = quiz.Title,
            NumberOfQuestions = quiz.NumberOfQuestions,
            TotalPoints = quiz.TotalPoints,
            StartAt = quiz.StartAt,
            EndAt = quiz.EndAt,
            Status = quiz.Status.ToString(),
            Questions = quiz.Questions.Select(QuestionResponse.From).ToList()
        };
    }
}
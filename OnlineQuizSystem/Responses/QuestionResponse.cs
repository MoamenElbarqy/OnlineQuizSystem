using OnlineQuizSystem.Models;

namespace OnlineQuizSystem.Responses;

public class QuestionResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int Points { get; set; }
    public IEnumerable<string> Choices { get; set; }
    public static QuestionResponse From(Question question)
    {
        return new QuestionResponse
        {
            Id = question.Id,
            Title = question.Title,
            Points = question.Points,
            Choices = question.Choices.Select(c => c.Text)
        };
    }
}
namespace OnlineQuizSystem.Models;

public class Choice
{
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public string Text { get; set; }
    public Question Question { get; set; }
}
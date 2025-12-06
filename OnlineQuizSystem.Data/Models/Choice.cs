namespace OnlineQuizSystem.Data.Models;

public class Choice
{
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public int ChoiceIndex { get; set; } // 1 Based
    public string Text { get; set; }
    public Question Question { get; set; }
}
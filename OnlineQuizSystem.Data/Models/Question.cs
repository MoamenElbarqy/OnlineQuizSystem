namespace OnlineQuizSystem.Data.Models;

public class Question
{
    public Guid Id { get; set; }
    public Guid QuizId {get; set;}
    public string Title { get; set; }
    public List<Choice> Choices { get; set; } = new();
    public Guid CorrectChoiceId { get; set; }
    public int QuestionScore { get; set; }
    public Quiz Quiz { get; set; }
    public List<StudentQuestion> StudentQuestions { get; set; } = new();
}
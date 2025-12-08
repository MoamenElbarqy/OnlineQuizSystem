namespace OnlineQuizSystem.Data.Models;

public class Question
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public List<Choice> Choices { get; set; } = new();

    public Guid QuizId { get; set; }
    public Guid CorrectChoiceId { get; set; }
    public Choice CorrectChoice { get; set; }
    
    public int Points { get; set; }
    public Quiz Quiz { get; set; }
    public List<StudentQuestion> StudentQuestions { get; set; } = new();
}
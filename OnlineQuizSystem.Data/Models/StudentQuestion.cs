namespace OnlineQuizSystem.Data.Models;

public class StudentQuestion
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid QuestionId { get; set; }
    public Guid StudentQuizId { get; set; }
    public Choice StudentChoice { get; set; } // 1 Based
    
    public bool IsCorrect => StudentChoice == Question.CorrectChoice;
    public StudentQuiz StudentQuiz { get; set; }
    public Student Student { get; set; }
    public Question Question { get; set; }
}
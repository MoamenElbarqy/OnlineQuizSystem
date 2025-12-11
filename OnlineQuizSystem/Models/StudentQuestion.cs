namespace OnlineQuizSystem.Models;

public class StudentQuestion
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid QuestionId { get; set; }
    public Guid StudentQuizId { get; set; }

    public Guid StudentChoiceId { get; set; }
    public Choice StudentChoice { get; set; }
    
    public bool IsCorrect => StudentChoiceId == Question.CorrectChoiceId;
    public StudentQuiz StudentQuiz { get; set; }
    public Student Student { get; set; }
    public Question Question { get; set; }
}
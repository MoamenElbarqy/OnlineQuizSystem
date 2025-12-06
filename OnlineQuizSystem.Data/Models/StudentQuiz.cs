namespace OnlineQuizSystem.Data.Models;

public class StudentQuiz
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid QuizId { get; set; }
    
    public Student Student { get; set; }
    public Quiz Quiz { get; set; }
     
    public List<StudentQuestion> SolvedQuestions { get; set; } = new();
    public DateTime StartedAt { get; set; }
    public DateTime? SubmittedAt { get; set; }
}
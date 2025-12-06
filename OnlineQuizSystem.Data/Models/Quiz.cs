namespace OnlineQuizSystem.Data.Models;

public class Quiz
{
    public Guid Id { get; set; }
    public Guid InstructorId { get; set; }
    public string Title { get; set; }
    public List<StudentQuiz> StudentQuizzes { get; set; }
    public List<Question> Questions { get; set; }
    
    public Instructor Instructor { get; set; }
    public DateTime CreatedAt { get; set; }
}
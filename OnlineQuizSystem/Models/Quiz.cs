using OnlineQuizSystem.Enums;

namespace OnlineQuizSystem.Models;

public class Quiz
{
    public Guid Id { get; set; }
    public Guid InstructorId { get; set; }
    public string Title { get; set; }
    public List<StudentQuiz> StudentQuizzes { get; set; } = new();
    public List<Question> Questions { get; set; } = new();
    public Instructor Instructor { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public int NumberOfQuestions => Questions.Count;
    public int TotalPoints => Questions.Sum(q => q.Points);

    public QuizStatus Status
    {
        get
        {
            var now = DateTime.UtcNow;
            if (now < StartAt)
                return QuizStatus.NotStarted;
            else if (now >= StartAt && now <= EndAt)
                return QuizStatus.InProgress;
            else
                return QuizStatus.Completed;
        }
    }
}
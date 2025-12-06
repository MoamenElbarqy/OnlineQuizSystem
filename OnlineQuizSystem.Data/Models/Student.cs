namespace OnlineQuizSystem.Data.Models;

public class Student: User
{
    public string Department { get; set; }
    public int Level { get; set; }
    public List<StudentQuiz> SolvedQuizzes { get; set; } = new();
    public List<StudentQuestion> SolvedQuestions { get; set; } = new();
}
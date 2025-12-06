namespace OnlineQuizSystem.Data.Models;


public class Instructor: User
{
    public decimal Salary { get; set; }
    public List<Quiz> Quizzes { get; set; }
}

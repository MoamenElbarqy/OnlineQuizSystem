namespace OnlineQuizSystem.Business.Request;


public class CreateQuizRequest
{
    public string Title { get; set; }
    public int NumberOfQuestions { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public List<CreateQuestionRequest> Questions { get; set; }
    
}
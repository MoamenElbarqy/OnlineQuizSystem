namespace OnlineQuizSystem.Requests;

public class UpdateQuizRequest
{
    public string Title { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public List<UpdateQuestionRequest> Questions { get; set; }
    public float MinDegreesToPass { get; set; }

}

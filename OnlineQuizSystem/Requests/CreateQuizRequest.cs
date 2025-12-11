using OnlineQuizSystem.Requests;

namespace OnlineQuizSystem.Requests;

public class CreateQuizRequest
{
    public string Title { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public List<CreateQuestionRequest> Questions { get; set; }
    public int MinDegreesToPass { get; set; }
    
}


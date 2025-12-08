
namespace OnlineQuizSystem.Business.Request;



public class CreateQuestionRequest
{
    public string Title { get; set; }
    public List<CreateChoiceRequest> Choices { get; set; }
    public int CorrectchoiceIndex { get; set; } // 0 based
}

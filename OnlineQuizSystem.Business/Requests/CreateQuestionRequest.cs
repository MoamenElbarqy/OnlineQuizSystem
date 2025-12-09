namespace OnlineQuizSystem.Business.Request;



public class CreateQuestionRequest
{
    public string Text { get; set; }
    public List<string> Choices { get; set; }
    public int CorrectChoiceIndex { get; set; } // 0 based
    public int Points { get; set; }
}


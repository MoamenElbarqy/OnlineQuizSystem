namespace OnlineQuizSystem.Requests;

public class UpdateQuestionRequest
{
    public string Title { get; set; }
    public List<string> Choices { get; set; }
    public int CorrectChoiceIndex { get; set; }
    public int Points { get; set; }

    public int DisplayOrder { get; set; }

}

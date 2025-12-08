
namespace OnlineQuizSystem.Business.Request;



public class CreateQuestionRequest
{
<<<<<<< HEAD
    public string Title { get; set; }
    public List<CreateChoiceRequest> Choices { get; set; }
    public int CorrectchoiceIndex { get; set; } // 0 based
}
=======
    public string Text { get; set; }
    public List<string> Choices { get; set; }
    public int CorrectChoiceIndex { get; set; } // 0 based
    public int Points { get; set; }
}

>>>>>>> login-authentication-branch

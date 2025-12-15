namespace OnlineQuizSystem.Requests;

public class CreateQuestionAttemptRequest
{
    public Guid QuestionId { get; set; }
    public Guid SelectedChoiceId { get; set; }
}
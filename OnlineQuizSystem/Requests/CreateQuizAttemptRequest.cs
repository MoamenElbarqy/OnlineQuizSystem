namespace OnlineQuizSystem.Requests;

public class CreateQuizAttemptRequest
{
    public Guid QuizId { get; set; }
    public List<CreateQuestionAttemptRequest> QuestionAttempts { get; set; }

    public DateTime SubmittedAt { get; set; }
}


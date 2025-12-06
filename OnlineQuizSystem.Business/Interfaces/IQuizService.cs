using OnlineQuizSystem.Business.Request;
using OnlineQuizSystem.Business.Response;


namespace OnlineQuizSystem.Business.Interfaces;

public interface IQuizService
{
    public Task<bool> Create(CreateQuizRequest request);
    public Task<bool> Delete(Guid id);
    public Task<bool> Update(Guid id, UpdateQuizRequest request);
    public Task<QuizResponse> GetById(Guid id);
    public Task<IEnumerable<QuizResponse>> GetAll();
    public Task StartQuiz(Guid id);
    public Task SubmitQuiz(Guid id);
}
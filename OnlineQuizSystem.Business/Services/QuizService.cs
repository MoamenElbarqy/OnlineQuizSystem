using OnlineQuizSystem.Business.Interfaces;
using OnlineQuizSystem.Business.Request;
using OnlineQuizSystem.Business.Response;

namespace OnlineQuizSystem.Business.Services;

public class QuizService:IQuizService
{
    QuizService()
    {
        
    }
    public Task<bool> Create(CreateQuizRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(Guid id, UpdateQuizRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<QuizResponse> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<QuizResponse>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task StartQuiz(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task SubmitQuiz(Guid id)
    {
        throw new NotImplementedException();
    }
}
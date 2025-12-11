using OnlineQuizSystem.Business.Request;
using OnlineQuizSystem.Business.Services;

namespace OnlineQuizSystem.Interfaces;

public interface IQuestionService
{
    public Task<bool> Create(CreateQuestionRequest request);
    public Task<bool> Delete(Guid id);
    public Task<bool> Update(Guid id, UpdateQuestionRequest request);
    public Task<QuestionResponse> GetById(Guid id);
    public Task<IEnumerable<QuestionResponse>> GetAll();
    public Task<IEnumerable<QuestionResponse>> GetAllStudentAnswers(Guid id);
}
using OnlineQuizSystem.Business.Request;
using OnlineQuizSystem.Models;

namespace OnlineQuizSystem.Interfaces;

public interface IQuizService
{
    public Task<bool> Create(CreateQuizRequest request, Guid instructorId);
    public Task<bool> Delete(Guid id, Guid instructorId);
    public Task<bool> Update(Guid id, UpdateQuizRequest request, Guid instructorId);
    public Task<Quiz> GetById(Guid id, Guid instructorId);

    public Task<Quiz> GetById(Guid id);
    public Task<IEnumerable<Quiz>> GetAll(Guid instructorId);
}
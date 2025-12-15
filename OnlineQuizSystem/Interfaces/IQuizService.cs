using OnlineQuizSystem.Models;
using OnlineQuizSystem.Requests;

namespace OnlineQuizSystem.Interfaces;

public interface IQuizService
{
    public Task<Quiz?> CreateQuizAsync(CreateQuizRequest request, Guid instructorId);
    public Task<bool> DeleteAsync(Guid id, Guid instructorId);
    public Task<Quiz?> UpdateQuizAsync(Guid id, UpdateQuizRequest request, Guid instructorId);
    public Task<Quiz?> GetByIdAsync(Guid id, Guid instructorId);
    public Task<Quiz?> GetByIdAsync(Guid id);

    public Task<IEnumerable<Quiz>> GetAllQuizzesAsync(Guid instructorId);
}
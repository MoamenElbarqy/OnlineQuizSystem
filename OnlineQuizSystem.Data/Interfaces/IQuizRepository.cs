using OnlineQuizSystem.Data.Models;

namespace OnlineQuizSystem.Data.Interfaces;

public interface IQuizRepository
{
    Task<Quiz> GetByIdAsync(Guid id);
    Task<IEnumerable<Quiz>> GetByInstructorIdAsync(Guid instructorId);
    Task<bool> AddAsync(Quiz quiz);
    Task<bool> UpdateAsync(Quiz quiz);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
}

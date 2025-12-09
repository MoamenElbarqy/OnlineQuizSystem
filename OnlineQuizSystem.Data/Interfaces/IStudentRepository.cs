using OnlineQuizSystem.Data.Models;

namespace OnlineQuizSystem.Data.Repositories;

public interface IStudentRepository
{
    bool Add(Student student);
    bool Delete(Student student);
    Student? Find(Guid id);
    Student? Find(string email, string password);
    bool Update(Student student);
}

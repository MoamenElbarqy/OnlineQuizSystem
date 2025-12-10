using OnlineQuizSystem.Data.Models;

namespace OnlineQuizSystem.Data.Repositories;

public class StudentRepository(AppDbContext context) : IStudentRepository
{
    public Student? Find(Guid id)
    {
        var student = context.Students
            .FirstOrDefault(s => s.Id == id);

        return student;

    }

    public Student? Find(string email, string password)
    {
        var student = context.Students
            .FirstOrDefault(s => s.Email == email && s.Password == password);

        return student;
    }
    public bool Add(Student student)
    {
        context.Students.Add(student);
        var changes = context.SaveChanges();
        return changes > 0;

    }
    public bool Update(Student student)
    {
        context.Students.Update(student);
        var changes = context.SaveChanges();
        return changes > 0;
    }
    public bool Delete(Student student)
    {
        context.Students.Remove(student);
        var changes = context.SaveChanges();
        return changes > 0;
    }

}

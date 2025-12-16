using OnlineQuizSystem.Models;

namespace OnlineQuizSystem.Responses;

class StudentResponse
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }

    public int Level { get; private set; }
    public string Department { get; private set; }

    public static StudentResponse From(Student student)
    {
        return new StudentResponse
        {
            Id = student.Id,
            Name = student.Name,
            Email = student.Email,
            Level = student.Level,
            Department = student.Department
        };
    }
}
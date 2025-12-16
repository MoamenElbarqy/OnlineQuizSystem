namespace OnlineQuizSystem.Responses;

class InstructorResponse
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public decimal Salary { get; private set; }

    public static InstructorResponse From(Models.Instructor instructor)
    {
        return new InstructorResponse
        {
            Id = instructor.Id,
            Name = instructor.Name,
            Email = instructor.Email,
            Salary = instructor.Salary
        };
    }
}
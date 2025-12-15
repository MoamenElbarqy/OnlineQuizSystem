namespace OnlineQuizSystem.Requests;

public class CreateInstructorRequest
{
    public CreateUserRequest UserInfo { get; set; }
    public decimal Salary { get; set; }
}

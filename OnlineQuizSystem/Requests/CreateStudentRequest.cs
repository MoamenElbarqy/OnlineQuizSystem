namespace OnlineQuizSystem.Requests;

public class CreateStudentRequest
{
    public CreateUserRequest UserInfo { get; set; }
    public string Department { get; set; }
    public int Level { get; set; }

}

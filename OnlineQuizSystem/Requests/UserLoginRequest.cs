using OnlineQuizSystem.Data.Enums;

namespace OnlineQuizSystem.Requests;

public class UserLoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
}
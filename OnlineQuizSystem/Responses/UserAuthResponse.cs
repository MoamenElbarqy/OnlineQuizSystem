using OnlineQuizSystem.Enums;

namespace OnlineQuizSystem.Responses;

public class UserAuthResponse
{
    public string Username { get; set; }
    public Role Role { get; set; }
}

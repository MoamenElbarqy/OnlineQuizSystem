using OnlineQuizSystem.Data.Enums;

namespace OnlineQuizSystem.API.Responses;

public class UserDto
{
    public string Username { get; set; }
    public Role Role { get; set; }
}
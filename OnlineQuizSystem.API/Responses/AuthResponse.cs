using OnlineQuizSystem.API.Responses;
using OnlineQuizSystem.Data.Enums;

namespace OnlineQuizSystem.API.Models;

public class AuthResponse
{
    public string AccessToken { get; set; }
    public DateTime ExpiresAt { get; set; }
    public UserDto User { get; set; }
}

using OnlineQuizSystem.Data.Enums;

namespace OnlineQuizSystem.API.Response;

public class UserTokenResponse
{
    public string Username { get; set; }
    public string UserEmail { get; set; }
    public Role Role { get; set; }
    public string AceessToken { get; set; }
    public string RefreshToken { get; set; }
    public DateTime ExpiresIn { get; set; }
}
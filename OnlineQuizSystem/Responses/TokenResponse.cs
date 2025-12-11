using OnlineQuizSystem.Models;

namespace OnlineQuizSystem.Response;

public class TokenResponse
{
    public string AccessToken { get; set; }
    public RefreshToken RefreshToken { get; set; }
    public DateTime ExpiresIn { get; set; }
}
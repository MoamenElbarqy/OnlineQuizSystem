using OnlineQuizSystem.Data.Enums;
using OnlineQuizSystem.Data.Models;

namespace OnlineQuizSystem.API.Response;

public class TokenResponse
{
    public string AccessToken { get; set; }
    public RefreshToken RefreshToken { get; set; }
    public DateTime ExpiresIn { get; set; }
}
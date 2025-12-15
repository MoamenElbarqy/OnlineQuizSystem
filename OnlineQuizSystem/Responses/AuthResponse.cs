namespace OnlineQuizSystem.Responses;


public class AuthResponse
{
    public string AccessToken { get; set; }
    public DateTime ExpiresAt { get; set; }
    public UserAuthResponse User { get; set; }
}

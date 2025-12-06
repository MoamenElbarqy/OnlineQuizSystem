namespace OnlineQuizSystem.API.Services;

public class RefreshTokenRequest
{
    public Guid Id { get; set; }
    public string RefreshToken { get; set; }
}
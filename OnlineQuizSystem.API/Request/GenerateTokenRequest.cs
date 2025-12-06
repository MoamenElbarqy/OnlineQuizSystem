using OnlineQuizSystem.Data.Enums;

namespace OnlineQuizSystem.API.Services;

public class GenerateTokenRequest
{
    public Guid Id { get; set; }
    public Role Role { get; set; }
}
using OnlineQuizSystem.Data.Enums;

namespace OnlineQuizSystem.Requests;

public class GenerateTokenRequest
{
    public Guid Id { get; set; }
    public Role Role { get; set; }
}
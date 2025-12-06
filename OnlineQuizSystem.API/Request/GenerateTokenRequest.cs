using OnlineQuizSystem.Data.Models;

namespace OnlineQuizSystem.API.Services;

public class GenerateTokenRequest
{
    public Guid Id { get; set; }
    public Role Role { get; set; }
}
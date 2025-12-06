using OnlineQuizSystem.Data.Enums;

namespace OnlineQuizSystem.Data.Models;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }

    List<RefreshToken> RefreshTokens { get; set; } = new();
}

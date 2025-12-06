using OnlineQuizSystem.Data.Enums;

namespace OnlineQuizSystem.API.Models;

public class AuthModel
{
    public string AccessToken { get; set; }
    public string Username { get; set; }
    public string UserEmail { get; set; }

    public Role role { get; set; }
}
 
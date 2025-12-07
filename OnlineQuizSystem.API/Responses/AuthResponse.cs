using OnlineQuizSystem.API.Responses;
using OnlineQuizSystem.Data.Enums;

namespace OnlineQuizSystem.API.Models;

public class AuthResponse
{
    public string AccessToken { get; set; }
    public DateTime ExpiresAt { get; set; }
    public UserDto User { get; set; }
}


/*
    The Response JSON structure will be like this:
    {
        "accessToken": "ToekenStringHere",
        "expiresAt": "2024-06-10T12:34:56.789Z",
        user : {
            "username": "Moamen",
            "role": "Admin"
        }
    }
*/
using OnlineQuizSystem.Business.Requests;
using OnlineQuizSystem.Data.Models;

namespace OnlineQuizSystem.Business.Interfaces;

public interface IAdminService
{
    public Task<Admin?> IsExisted(UserLoginRequest request);
}

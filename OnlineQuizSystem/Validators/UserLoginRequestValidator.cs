using FluentValidation;
using OnlineQuizSystem.Requests;

namespace OnlineQuizSystem.Validators;

class UserLoginRequestValidator : AbstractValidator<UserLoginRequest>
{
    public UserLoginRequestValidator()
    {
        RuleFor(u => u.Email).NotEmpty().EmailAddress();
        RuleFor(u => u.Password).NotEmpty();
        RuleFor(u => u.Role).IsInEnum();
    }
}